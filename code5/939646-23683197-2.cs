    public class CassandraDAO
    {
        private Cluster cluster;
        private Session session;
        private String NODE = ABCServiceTester.Properties.Settings.Default.CASSANDRA_NODE;
        private String USER = ABCServiceTester.Properties.Settings.Default.USERNAME;
        private String PASS = ABCServiceTester.Properties.Settings.Default.PASSWORD;
        public CassandraDAO()
        {
            connect();
        }
        private void connect()
        {
            cluster = Cluster.Builder().WithCredentials(USER, PASS)
                .AddContactPoint(NODE).Build();
            session = cluster.Connect();
        }
        protected Session getSession()
        {
            if (session == null)
            {
                connect();
            }
            return session;
        }
    }
