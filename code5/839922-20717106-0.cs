    public class CoreConnectorFactory : IConnectorFactory
    {
      private static CoreConnector conn;
      public IConnector CreateConnector(string id)
      {
        if (conn==null) conn = new CoreConnector();
        return conn;
      }
    }
  
    public class LoggingConnectorFactory : IConnectorFactory
    {
      private readonly IConnectorFactory cf;
      public LoggingConnectorFactory(IConnectorFactory cf)
      {
        this.cf = cf;
      }
      public IConnector CreateConnector(string id)
      {
        return new LoggingConnector(cf.CreateConnector(id),id);
      }
    }
  
    public class AuditingConnectorFactory : IConnectorFactory
    {
      private readonly IConnectorFactory cf;
      public AuditingConnectorFactory(IConnectorFactory cf)
      {
        this.cf = cf;
      }
      public IConnector CreateConnector(string id)
      {
        return new AuditingConnector(cf.CreateConnector(id),id);
      }
    }
    class Tests
    {
      public static void Test()
      {
        var coreConnectorFactory     = new CoreConnectorFactory();
        var auditingConnectorFactory = new AuditingConnectorFactory(coreConnectorFactory);
        var loggingConnectorFactory  = new LoggingConnectorFactory(auditingConnectorFactory);
        var connector                = loggingConnectorFactory.CreateConnector("12345");
        connector.Connect();
      }
    }
