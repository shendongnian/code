    public class SomeController : ControllerBase
    {
        public IActionResult Method([FromQuery]IDictionary<int, string> query)
        {
            // Do something
        }
    }
