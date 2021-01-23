    public class CassandraDAO
    {
        private Cluster cluster;
        private String NODE = ABCServiceTester.Properties.Settings.Default.CASSANDRA_NODE;
        private String USER = ABCServiceTester.Properties.Settings.Default.USERNAME;
        private String PASS = ABCServiceTester.Properties.Settings.Default.PASSWORD;
        protected Session connect()
        {
            cluster = Cluster.Builder().WithCredentials(USER, PASS)
                .AddContactPoint(NODE).Build();
            Session session = cluster.Connect();
            return session;
        }
    }
