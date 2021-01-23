    using Log4Net = log4net;
    
    namespace ClassLibrary1
    {
        public class Class1
        {
            private Log4Net.ILog log;
            public Class1()
            {
                log = Log4Net.LogManager.GetLogger(typeof (Class1));
                log.Debug("msg");
            }
        }
    }
