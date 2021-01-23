	namespace log4net
	{
		public interface ILog
		{
			/* Test if a level is enabled for logging */
			bool IsDebugEnabled { get; }
			bool IsInfoEnabled { get; }
			bool IsWarnEnabled { get; }
			bool IsErrorEnabled { get; }
			bool IsFatalEnabled { get; }
			
			/* Log a message object */
			void Info(object message);
			...
			
			/* Log a message object and exception */
			void Info(object message, Exception t);
			...
			
			/* Log a message string using the System.String.Format syntax */
			void InfoFormat(string format, params object[] args);
			...
			
			/* Log a message string using the System.String.Format syntax */
			void InfoFormat(IFormatProvider provider, string format, params object[] args);
			...
		}
	}
