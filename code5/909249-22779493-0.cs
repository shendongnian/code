    public class Neo4jModule : NinjectModule
    {
        /// <summary>Loads the module into the kernel.</summary>
        public override void Load()
        {
            Bind<IGraphClient>().ToMethod(InitNeo4JClient).InSingletonScope();
        }
    
        private static IGraphClient InitNeo4JClient(IContext context)
        {
            var neo4JUri = new Uri(ConfigurationManager.ConnectionStrings["Neo4j"].ConnectionString);
            var graphClient = new GraphClient(neo4JUri);
            graphClient.Connect();
    
            return graphClient;
        }
    }
