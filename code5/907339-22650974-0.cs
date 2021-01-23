    public class NHibernateSessionFactory
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    InitializeNHibernateSessionFactory();
                }
                return _sessionFactory;
            }
        }
        private static void InitializeNHibernateSessionFactory()
        {
            _sessionFactory =
                Fluently.Configure()
                    .Database(MySQLConfiguration.Standard
                    .ConnectionString(ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString))
                    .ShowSql())
                    .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<OneOfMyMappedClassesMap>()))
                    .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                    .BuildSessionFactory();
        }
    }
    
