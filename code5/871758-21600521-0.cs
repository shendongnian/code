    class MyLogger {
    
    private String dbname = String.Empty;
    
    public static String DbName {
        get { return dbname; }
        set { dbname = value; }
    }
    
    private static MyLogger mylogger = null;
    
    public static MyLogger Handle {
        get {
            if (logger == null) mylogger = new MyLogger(dbName);
            return mylogger;
        }
    }
    
    private MyLogger(String db) {
        // your code
        logger = LoggerConfigurator.AddNamedLogger(db);
    }
