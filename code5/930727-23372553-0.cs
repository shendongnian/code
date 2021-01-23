    public abstract class BaseConfig<T> where T : BaseConfig<T>
    {
        /// <summary>
        /// Database connection information
        /// </summary>
        public class Database
        {
            public String ServerName;
            public String DatabaseName;
            public bool IntegratedSecurity;
            public String UserName;
            public String Password;
            public String ConnectionStringOptions;
        }
        public Database DatabaseInfo { get; set; }
        public abstract SqlConnection ConnectToSQL(Database info);
    }
    public class MyConfig : BaseConfig<MyConfig>
    {
        public override SqlConnection ConnectToSQL(Database info)
        {
             ...
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cfg=new MyConfig();
            cfg.ConnectToSQL(cfg.DatabaseInfo);
        }
    }
