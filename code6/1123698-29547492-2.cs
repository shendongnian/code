    public class GenerationController : Controller
    {
        readonly HttpRequestBase _request;
        public GenerationController(
                HttpRequestBase request,
                // Additional constructor parameters goes here
            )
        {
            _request = request;
        }
    }
