    public class MemoryStreamController : ApiController 
    {
        private IMainService _service;
        public MemoryStreamController(Func<string, IMainService> mainService) 
        {
            _service = mainService("MemoryStreamService")
        }
    }
