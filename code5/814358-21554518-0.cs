    public class BaseController : Controller
    {
        private static ExceptionManager _exceptionManager;
        private static LogWriter _logWriter;
        public ExceptionManager ExceptionManager
        {
            get
            {
                IUnityContainer container = new UnityContainer();
                try
                {
                    if (_exceptionManager == null)
                    {
                        IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
                        ExceptionPolicyFactory exceptionFactory = new ExceptionPolicyFactory(configurationSource);
                        if (configurationSource.GetSection(LoggingSettings.SectionName) != null)
                        {
                            LogWriterFactory logWriterFactory = new LogWriterFactory(configurationSource);
                            Logger.SetLogWriter(logWriterFactory.Create());
                            
                        }
                        container.RegisterInstance<ExceptionManager>(exceptionFactory.CreateManager());
                        _exceptionManager = container.Resolve<ExceptionManager>();
                        return _exceptionManager;
                    }
                    else
                    {
                        return _exceptionManager;
                    }
                }
                finally
                {
                    ((IDisposable)container).Dispose();
                }
            }
            set
            {
                _exceptionManager = value;
            }
        }
        /// <summary>
        /// Used to log entries in the log file
        /// </summary>
        public LogWriter LogWriter
        {
            get
            {
                IUnityContainer container = new UnityContainer();
                try
                {
                    if (_logWriter == null)
                    {
                        IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
                        LogWriterFactory logWriterFactory = new LogWriterFactory(configurationSource);
                        Logger.SetLogWriter(logWriterFactory.Create());
                        // Singleton
                        container.RegisterInstance<LogWriter>(logWriterFactory.Create());
                        _logWriter = container.Resolve<LogWriter>();
                        return _logWriter;
                    }
                    else
                        return _logWriter;
                }
                finally
                {
                    ((IDisposable)container).Dispose();
                }
            }
            set
            {
                _logWriter = value;
            }
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es");
            
            if (Session.Count == 0)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });
            }
            
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            this.ExceptionManager.HandleException(filterContext.Exception, "AllExceptionsPolicy");
            //Show basic Error view
            filterContext.ExceptionHandled = true;
            //Clear any data in the model as it wont be needed
            ViewData.Model = null;
            //Show basic Error view
            View("Error").ExecuteResult(this.ControllerContext);
        }
    }
