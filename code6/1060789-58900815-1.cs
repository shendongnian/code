    [Route("api/[controller]")]
    public abstract class MyBaseController : Controller { ... }
    
    public class ProductsController : MyBaseController
    {
       [HttpGet] // Matches '/api/Products'
       public IActionResult List() { ... }
    
       [HttpPut("{id}")] // Matches '/api/Products/{id}'
       public IActionResult Edit(int id) { ... }
    }
