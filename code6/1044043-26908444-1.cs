    [ApiAuthorize]
    public class MyController: ApiController{
           private readonly IUnitOfWork _unitOfWork;
        private readonly ILoginService _loginService;
        private readonly ILog _log;
    
        // That method don't need authorization
        [AllowAnonymous]
        public LoginController(ILoginService loginService, IUnitOfWork unitOfWork, ILog log)
        {
            this._loginService = loginService;
            this._unitOfWork = unitOfWork;
            this._log = log;
        }
    
        // Before calling that method will be called logic from `ApiAuthorizeAttribute`
        public HttpResponseMessage Get(Guid id)
        {
            _log.Log(log something);
            // some code thats gets some data using this._loginService
            _log.Log(log the save);
             _unitOfWork.Save();
        }
    }
