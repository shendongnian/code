    [UserTokenAuthentication] // magic attribute in use
    [Log] // magic attribute in use
    public class MyController: ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoginService _loginService;
        private readonly ILog _log;
        public MyController(ILoginService loginService, IUnitOfWork unitOfWork, ILog log)
        {
            this._loginService = loginService;
            this._unitOfWork = unitOfWork;
            this._log = log;
        }
        
        [System.Web.Http.AllowAnonymous] // doesnt require authentication as were not logged in yet
        public HttpResponseMessage Get(Guid id)
        {
            _log.Log(log something);
            // some code thats gets some data using this._loginService
            _log.Log(log the save);
             _unitOfWork.Save();
        }
        
        public HttpResponseMessage GetMyDetails(Guid id)
        {
            _log.Log(log something);
            // some code thats gets some data using this._loginService
            _log.Log(log the save);
             _unitOfWork.Save();
        }
    }   
