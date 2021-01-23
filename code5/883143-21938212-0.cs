    public interface ILog
    {
        [StringFormatMethodAttribute("format")]
        void Debug(string format, params object[] args);
        [StringFormatMethodAttribute("format")]
        void Info(string format, params object[] args);
        [StringFormatMethodAttribute("format")]
        void Warn(string format, params object[] args);
        [StringFormatMethodAttribute("format")] 
        void Error(string format, params object[] args);
        void Error(Exception ex);
        [StringFormatMethodAttribute("format")]
        void Error(Exception ex, string format, params object[] args);
        [StringFormatMethodAttribute("format")]
        void Fatal(Exception ex, string format, params object[] args);
    }
    public class NLogLogger : ILog
    {
        private readonly Logger _log;
        public NLogLogger(Type type)
        {
            _log = LogManager.GetLogger(type.FullName);
        }
        public void Debug(string format, params object[] args)
        {
            Log(LogLevel.Debug, format, args);
        }
        public void Info(string format, params object[] args)
        {
            Log(LogLevel.Info, format, args);
        }
        public void Warn(string format, params object[] args)
        {
            Log(LogLevel.Warn, format, args);
        }
        public void Error(string format, params object[] args)
        {
            Log(LogLevel.Error, format, args);
        }
        public void Error(Exception ex)
        {
            Log(LogLevel.Error, null, null, ex);
        }
        public void Error(Exception ex, string format, params object[] args)
        {
            Log(LogLevel.Error, format, args, ex);
        }
        public void Fatal(Exception ex, string format, params object[] args)
        {
            Log(LogLevel.Fatal, format, args, ex);
        }
        private void Log(LogLevel level, string format, object[] args)
        {
            _log.Log(typeof (NLogLogger), new LogEventInfo(level, _log.Name, null, format, args));
        }
        private void Log(LogLevel level, string format, object[] args, Exception ex)
        {
            _log.Log(typeof (NLogLogger), new LogEventInfo(level, _log.Name, null, format, args, ex));
        }
    }
    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register((c, p) => new NLogLogger(p.TypedAs<Type>()))
                .AsImplementedInterfaces();
        }
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            registration.Preparing +=
                (sender, args) =>
                {
                    var forType = args.Component.Activator.LimitType;
                    var logParameter = new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(ILog),
                        (p, c) => c.Resolve<ILog>(TypedParameter.From(forType)));
                    args.Parameters = args.Parameters.Union(new[] { logParameter });
                };
        }
    }
