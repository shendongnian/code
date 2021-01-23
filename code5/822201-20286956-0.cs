	public class CombinedLoggerFactory : ILoggerFactory
	{
		IList<ILoggerFactory> factories = new List<ILoggerFactory> {
			new Log4NetLoggerFactory(),
			new NHibernate.Glimpse.LoggerFactory()
		};
		public CombinedLoggerFactory()
		{
		}
		public IInternalLogger LoggerFor( Type type )
		{
			return new CombinedLogger( factories.Select( f => f.LoggerFor( type )));
		}
		public IInternalLogger LoggerFor( string keyName )
		{
			return new CombinedLogger( factories.Select( f => f.LoggerFor( keyName )));
		}
	}
	internal static class IEnumerableExtensions
	{
		internal static void ForEach<T>( this IEnumerable<T> list, Action<T> action )
		{
			foreach( var x in list ) {
				action(x);
			}
		}
	}
	internal class CombinedLogger : IInternalLogger
	{
		readonly IList<IInternalLogger> loggers;
		internal CombinedLogger( IEnumerable<IInternalLogger> logs )
		{
			loggers = logs.ToList();
		}
		public void Debug( object message, Exception exception )
		{
			loggers.Where( l => l.IsDebugEnabled )
				.ForEach( l => l.Debug( message, exception ));
		}
		public void Debug( object message )
		{
			loggers.Where( l => l.IsDebugEnabled )
				.ForEach( l => l.Debug( message ));
		}
		public void DebugFormat( string format, params object[] args )
		{
			loggers.ForEach( l => l.DebugFormat( format, args ));
		}
		public void Error( object message, Exception exception )
		{
			loggers.Where( l => l.IsErrorEnabled )
				.ForEach( l => l.Error( message, exception ));
		}
		public void Error( object message )
		{
			loggers.Where( l => l.IsErrorEnabled )
				.ForEach( l => l.Error( message ));
		}
		public void ErrorFormat( string format, params object[] args )
		{
			loggers.ForEach( l => l.ErrorFormat( format, args ));
		}
		public void Fatal( object message, Exception exception )
		{
			loggers.Where( l => l.IsFatalEnabled )
				.ForEach( l => l.Fatal( message, exception ));
		}
		public void Fatal( object message )
		{
			loggers.Where( l => l.IsFatalEnabled )
				.ForEach( l => l.Fatal( message ));
		}
		public void Info( object message, Exception exception )
		{
			loggers.Where( l => l.IsInfoEnabled )
				.ForEach( l => l.Info( message, exception ));
		}
		public void Info( object message )
		{
			loggers.Where( l => l.IsInfoEnabled )
				.ForEach( l => l.Info( message ));
		}
		public void InfoFormat( string format, params object[] args )
		{
			loggers.ForEach( l => l.InfoFormat( format, args ));
		}
		public bool IsDebugEnabled
		{
			get { return loggers.Any( l => l.IsDebugEnabled ); }
		}
		public bool IsErrorEnabled
		{
			get { return loggers.Any( l => l.IsErrorEnabled ); }
		}
		public bool IsFatalEnabled
		{
			get { return loggers.Any( l => l.IsFatalEnabled ); }
		}
		public bool IsInfoEnabled
		{
			get { return loggers.Any( l => l.IsInfoEnabled ); }
		}
		public bool IsWarnEnabled
		{
			get { return loggers.Any( l => l.IsWarnEnabled ); }
		}
		public void Warn( object message, Exception exception )
		{
			loggers.Where( l => l.IsWarnEnabled )
				.ForEach( l => l.Warn( message, exception ));
		}
		public void Warn( object message )
		{
			loggers.Where( l => l.IsWarnEnabled )
				.ForEach( l => l.Warn( message ));
		}
		public void WarnFormat( string format, params object[] args )
		{
			loggers.ForEach( l => l.WarnFormat( format, args ));
		}
	}
