    Interface IConnectionProvider
    {
       ConnectionName { get;}
    }
    class LanguageAProvider : IConnectionProvider
    {
        public string ConnectionName { get { return "dbnameLangA"; }  }
    }
    class LanguageBProvider : IConnectionProvider
    {
        public string ConnectionName { get { return "dbnameLangB"; }  }
    }
    public class MyqlMembershipProvider : SqlMembershipProvider
    {
        private readonly string _connectionStringName;
        public MyqlMembershipProvider (IConnectionProvider connection)
        {
            _connectionStringName = connection.ConnectionName;
        }
    
            public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
            {
                var connectionString = GetConnectionStringFromSelectedLanguage();
    
                config[_connectionStringName] = _connectionStringName;//I'm not sure how you need to use the connection name here.
                base.Initialize(name, config);            
            }
    }
