    public class DoWork {
        private IApplicationRootService _applicationRootService;
        public DoWork(IApplicationRootService applicationRootService) {
            _applicationRootService = applicationRootService;
        }
        public void DoSomething() {
            var appRoot = _applicationRooService.GetApplicationRoot();
            //do your stuff
        }
    }
