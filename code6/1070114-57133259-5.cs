    namespace Sample.Api.Controllers
    {
        [ApiController]
        public class XController : ControllerBase
        {
            [HttpPost]
            public IActionResult Post(XModel model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                // ...
            }
        }
    }
