    using System;
    using Castle.Core.Logging;
    using Castle.Facilities.Logging;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using log4net;
    
    namespace Castle_Log4Net
    {
        public class Installer : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, 
                                IConfigurationStore store)
            {
                container.AddFacility<LoggingFacility>
                        (f => f.LogUsing<Log4NetLoggingFactory>());
            }
        }
    
        public class Log4NetLoggingFactory : Castle.Core.Logging.ILoggerFactory
        {
            static Log4NetLoggingFactory()
            {
                // here you configure log4net from log4netConfigSetup.cs
            }
    
            public ILogger Create(Type type)
            {
                return new Log4NetLogger(type);
            }
    
            public ILogger Create(string name)
            {
                return new Log4NetLogger(name);
            }
    
            public ILogger Create(Type type, LoggerLevel level)
            {
                throw new NotImplementedException();
            }
    
            public ILogger Create(string name, LoggerLevel level)
            {
                throw new NotImplementedException();
            }
        }
    
        public class Log4NetLogger : Castle.Core.Logging.ILogger
        {
            private readonly ILog logger;
    
            public Log4NetLogger(Type type)
            {
                this.logger = LogManager.GetLogger(type);
            }
    
            public Log4NetLogger(string name)
            {
                this.logger = LogManager.GetLogger(name);
            }
    
            public ILogger CreateChildLogger(string loggerName)
            {
                throw new NotImplementedException();
            }
    
            public void Debug(string message)
            {
                logger.Debug(message);
            }
    
            public void Debug(Func<string> messageFactory)
            {
                logger.Debug(messageFactory.Invoke());
            }
    
            public void Debug(string message, Exception exception)
            {
                logger.Debug(message, exception);
            }
    
            public void DebugFormat(string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void DebugFormat(Exception exception, string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void DebugFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void Error(string message)
            {
                throw new NotImplementedException();
            }
    
            public void Error(Func<string> messageFactory)
            {
                throw new NotImplementedException();
            }
    
            public void Error(string message, Exception exception)
            {
                throw new NotImplementedException();
            }
    
            public void ErrorFormat(string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void ErrorFormat(Exception exception, string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void ErrorFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void Fatal(string message)
            {
                throw new NotImplementedException();
            }
    
            public void Fatal(Func<string> messageFactory)
            {
                throw new NotImplementedException();
            }
    
            public void Fatal(string message, Exception exception)
            {
                throw new NotImplementedException();
            }
    
            public void FatalFormat(string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void FatalFormat(Exception exception, string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void FatalFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void Info(string message)
            {
                throw new NotImplementedException();
            }
    
            public void Info(Func<string> messageFactory)
            {
                throw new NotImplementedException();
            }
    
            public void Info(string message, Exception exception)
            {
                throw new NotImplementedException();
            }
    
            public void InfoFormat(string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void InfoFormat(Exception exception, string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void InfoFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void Warn(string message)
            {
                throw new NotImplementedException();
            }
    
            public void Warn(Func<string> messageFactory)
            {
                throw new NotImplementedException();
            }
    
            public void Warn(string message, Exception exception)
            {
                throw new NotImplementedException();
            }
    
            public void WarnFormat(string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void WarnFormat(Exception exception, string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public void WarnFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
            {
                throw new NotImplementedException();
            }
    
            public bool IsDebugEnabled { get; private set; }
            public bool IsErrorEnabled { get; private set; }
            public bool IsFatalEnabled { get; private set; }
            public bool IsInfoEnabled { get; private set; }
            public bool IsWarnEnabled { get; private set; }
        }
    }
