    public abstract class ExceptionHandlerService : IExceptionHandlerService
    {
        ILoggingService _loggingSerivce;
        protected ExceptionHandlerService(ILoggingService loggingService)
        {
            //Doing this allows my IoC component to resolve whatever I have
            //configured to log "stuff"
            _loggingService = loggingService;
                
        }
        public virtual void HandleException(Exception exception)
        {
           
            //I use elmah a alot - and this can handle WebAPI 
           //or Task.Factory ()=> things where the context is null
            if (Elmah.ErrorSignal.FromCurrentContext() != null)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            }
            else
            {
                ErrorLog.GetDefault(null).Log(new Error(exception));
            }
            _loggingService.Log("something happened", exception)
        }
    }
