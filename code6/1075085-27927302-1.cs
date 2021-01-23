    public class LoggerFactory : ILoggerFactory
    {
        public LoggerFactory()
        {
        }
        
        public IInternalLogger LoggerFor(Type type)
        {
            return new AllCustomLogger();
        }
         
        public IInternalLogger LoggerFor(string keyName)
        {
            if (keyName == "NHibernate.SQL")
            {
                return new OnlySqlCustomLogger();
            }
            else
            {
                return new AllCustomLogger();
            }
        }
    }
    
    public class OnlySqlCustomLogger: IInternalLogger
    {
        public OnlySqlCustomLogger()
        {
        }
        
        public void Info(object message)
        {
            this.Log(message.ToString());
        }
        
    // etc...
    }
