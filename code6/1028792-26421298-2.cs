    public class DbLogger : Logger
    {
        public DbLogger (DbAppender appender) : base(appender)
        {        
        }
    }
    
    
    x.For<IHelloDbService>().Use<HelloServiceWithDbLog>();
                    .Ctor<ILogger>().Is<DbLogger>();
