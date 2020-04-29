using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Petstore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        private static List<Pets> listPets;
        private readonly ILogger<PetsController> _logger;

        public PetsController(ILogger<PetsController> logger)
        {
            _logger = logger;
            if(listPets == null)
            {
                listPets = new List<Pets>();
                listPets.Add(new Pets() { 
                    id = "123", 
                    name = "collar perro",
                    tag = "perro",
                });
                listPets.Add(new Pets() { 
                    id = "124", 
                    name = "collar gato",
                    tag = "gato",
                });
            }
           
        }

        [HttpGet]
        public IEnumerable<Pets> GetAll()
        {
            return listPets;
        }

        [HttpGet("{petId}")]
        public IEnumerable<Pets> Get(int petId)
        {
            if (!listsPets.Exists(p => p.id == petId))
            {
                return NotFound();
            }
            else
            {
                return listPets.FirstOrDefault(p => p.id == petId)
            }
        }

        [HttpPost]
        public Pets Post(Pets bodyParam)
        {
            listPets.Add(bodyParam);
            
            return bodyParam;
        }
    }
}
