    using log4net;
    using log4net.Core;
    using log4net.Repository;
    public class CountingLogger : ILog , ILogger
    {
      public IDictionary<Level , int> Counts { get; private set; }
      private ILog Log4Net { get; set; }
      public CountingLogger( ILog logger )
      {
        this.Log4Net = logger ;
        this.Counts  = this.Log4Net.Logger.Repository.LevelMap.AllLevels.Cast<Level>().ToDictionary( x => x , x => 0 ) ;
        return;
      }
      private void Count( Level level )
      {
        int count;
        bool success = this.Counts.TryGetValue( level , out count );
        this.Counts[level] = ++count;
        return;
      }
      public bool IsDebugEnabled { get { return Log4Net.IsDebugEnabled ; } }
      public bool IsErrorEnabled { get { return Log4Net.IsErrorEnabled ; } }
      public bool IsFatalEnabled { get { return Log4Net.IsFatalEnabled ; } }
      public bool IsInfoEnabled  { get { return Log4Net.IsInfoEnabled  ; } }
      public bool IsWarnEnabled  { get { return Log4Net.IsWarnEnabled  ; } }
      public ILogger Logger { get { return this ; } }
      public void Debug( object message , Exception exception ) { Count( Level.Debug ) ; Log4Net.Debug( message , exception ) ; }
      public void Info(  object message , Exception exception ) { Count( Level.Info  ) ; Log4Net.Info(  message , exception ) ; }
      public void Warn(  object message , Exception exception ) { Count( Level.Warn  ) ; Log4Net.Warn(  message , exception ) ; }
      public void Error( object message , Exception exception ) { Count( Level.Error ) ; Log4Net.Error( message , exception ) ; }
      public void Fatal( object message , Exception exception ) { Count( Level.Fatal ) ; Log4Net.Fatal( message , exception ) ; }
      public void Debug( object message ) { Count( Level.Debug ) ; Log4Net.Debug( message ) ; }
      public void Info(  object message ) { Count( Level.Info  ) ; Log4Net.Info(  message ) ; }
      public void Warn(  object message ) { Count( Level.Warn  ) ; Log4Net.Warn(  message ) ; }
      public void Error( object message ) { Count( Level.Error ) ; Log4Net.Error( message ) ; }
      public void Fatal( object message ) { Count( Level.Fatal ) ; Log4Net.Fatal( message ) ; }
      public void DebugFormat( IFormatProvider provider , string format , params object[] args ) { Count( Level.Debug ) ; Log4Net.DebugFormat( provider , format , args ) ; }
      public void InfoFormat(  IFormatProvider provider , string format , params object[] args ) { Count( Level.Info  ) ; Log4Net.InfoFormat(  provider , format , args ) ; }
      public void WarnFormat(  IFormatProvider provider , string format , params object[] args ) { Count( Level.Warn  ) ; Log4Net.WarnFormat(  provider , format , args ) ; }
      public void ErrorFormat( IFormatProvider provider , string format , params object[] args ) { Count( Level.Error ) ; Log4Net.ErrorFormat( provider , format , args ) ; }
      public void FatalFormat( IFormatProvider provider , string format , params object[] args ) { Count( Level.Fatal ) ; Log4Net.FatalFormat( provider , format , args ) ; }
      public void DebugFormat( string format , object arg0 , object arg1 , object arg2 ) { Count( Level.Debug ) ; Log4Net.DebugFormat( format , arg0 , arg1 , arg2 ) ; }
      public void InfoFormat(  string format , object arg0 , object arg1 , object arg2 ) { Count( Level.Info  ) ; Log4Net.InfoFormat(  format , arg0 , arg1 , arg2 ) ; }
      public void WarnFormat(  string format , object arg0 , object arg1 , object arg2 ) { Count( Level.Warn  ) ; Log4Net.WarnFormat(  format , arg0 , arg1 , arg2 ) ; }
      public void ErrorFormat( string format , object arg0 , object arg1 , object arg2 ) { Count( Level.Error ) ; Log4Net.ErrorFormat( format , arg0 , arg1 , arg2 ) ; }
      public void FatalFormat( string format , object arg0 , object arg1 , object arg2 ) { Count( Level.Fatal ) ; Log4Net.FatalFormat( format , arg0 , arg1 , arg2 ) ; }
      public void DebugFormat( string format , object arg0 , object arg1 ) { Count( Level.Debug ) ; Log4Net.DebugFormat( format , arg0 , arg1 ) ; }
      public void InfoFormat(  string format , object arg0 , object arg1 ) { Count( Level.Info  ) ; Log4Net.InfoFormat(  format , arg0 , arg1 ) ; }
      public void WarnFormat(  string format , object arg0 , object arg1 ) { Count( Level.Warn  ) ; Log4Net.WarnFormat(  format , arg0 , arg1 ) ; }
      public void ErrorFormat( string format , object arg0 , object arg1 ) { Count( Level.Error ) ; Log4Net.ErrorFormat( format , arg0 , arg1 ) ; }
      public void FatalFormat( string format , object arg0 , object arg1 ) { Count( Level.Fatal ) ; Log4Net.FatalFormat( format , arg0 , arg1 ) ; }
      public void DebugFormat( string format , object arg0 ) { Count( Level.Debug ) ; Log4Net.DebugFormat( format , arg0 ) ; }
      public void InfoFormat(  string format , object arg0 ) { Count( Level.Info  ) ; Log4Net.InfoFormat(  format , arg0 ) ; }
      public void WarnFormat(  string format , object arg0 ) { Count( Level.Warn  ) ; Log4Net.WarnFormat(  format , arg0 ) ; }
      public void ErrorFormat( string format , object arg0 ) { Count( Level.Error ) ; Log4Net.ErrorFormat( format , arg0 ) ; }
      public void FatalFormat( string format , object arg0 ) { Count( Level.Fatal ) ; Log4Net.FatalFormat( format , arg0 ) ; }
      public void DebugFormat( string format , params object[] args ) { Count( Level.Debug ) ; Log4Net.DebugFormat( format , args ) ; }
      public void InfoFormat(  string format , params object[] args ) { Count( Level.Info  ) ; Log4Net.InfoFormat(  format , args ) ; }
      public void WarnFormat(  string format , params object[] args ) { Count( Level.Warn  ) ; Log4Net.WarnFormat(  format , args ) ; }
      public void ErrorFormat( string format , params object[] args ) { Count( Level.Error ) ; Log4Net.ErrorFormat( format , args ) ; }
      public void FatalFormat( string format , params object[] args ) { Count( Level.Fatal ) ; Log4Net.FatalFormat( format , args ) ; }
      #region ILogger implementation
      bool ILogger.IsEnabledFor( Level level )
      {
        return this.Log4Net.Logger.IsEnabledFor( level ) ;
      }
      void ILogger.Log( LoggingEvent logEvent )
      {
        Count( logEvent.Level ) ;
        this.Log4Net.Logger.Log( logEvent ) ;
        return ;
      }
      void ILogger.Log( Type callerStackBoundaryDeclaringType , Level level , object message , Exception exception )
      {
        Count( level ) ;
        this.Log4Net.Logger.Log( callerStackBoundaryDeclaringType , level , message , exception ) ;
        return ;
      }
      string            ILogger.Name       { get { return this.Log4Net.Logger.Name       ; } }
      ILoggerRepository ILogger.Repository { get { return this.Log4Net.Logger.Repository ; } }
      #endregion
    }
    static class LoggerFactory
    {
      public static ILog GetLogger( string name )
      {
        ILog log             = LogManager.GetLogger( name );
        ILog decoratedLogger = new CountingLogger( log );
        return decoratedLogger;
      }
      public static ILog GetLogger( Type type )
      {
        ILog log             = LogManager.GetLogger( type );
        ILog decoratedLogger = new CountingLogger( log );
        return decoratedLogger;
      }
      public static ILog GetLogger( string repository , string name )
      {
        ILog log             = LogManager.GetLogger( repository , name );
        ILog decoratedLogger = new CountingLogger( log );
        return decoratedLogger;
      }
      public static ILog GetLogger( string repository , Type type )
      {
        ILog log             = LogManager.GetLogger( repository , type );
        ILog decoratedLogger = new CountingLogger( log );
        return decoratedLogger;
      }
      public static ILog GetLogger( Assembly repositoryAssembly , string name )
      {
        ILog log             = LogManager.GetLogger( repositoryAssembly , name );
        ILog decoratedLogger = new CountingLogger( log );
        return decoratedLogger;
      }
      public static ILog GetLogger( Assembly repositoryAssembly , Type type )
      {
        ILog log             = LogManager.GetLogger( repositoryAssembly , type );
        ILog decoratedLogger = new CountingLogger( log );
        return decoratedLogger;
      }
    }
