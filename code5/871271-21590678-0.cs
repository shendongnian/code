    public abstract class SqlFactory
    {
        public abstract DbConnection CreateConnection();
        public abstract DataAdapter CreateAdapter(string command, DbConnection connection);
    }
    public class SqlLiteFactory : SqlFactory
    {
        public override DbConnection CreateConnection()
        {
            return new SQLiteConnection("Data Source=Resources\\DB.sqlite;Version=3");
        }
        public override DataAdapter CreateAdapter(string command, DbConnection connection)
        {
            return new SQLiteDataAdapter(command, connection as SQLiteConnection);
        }
    }
    public class MSSqlFactory : SqlFactory
    {
        public override DbConnection CreateConnection()
        {
            return new SqlConnection("CONNECTION STRING HERE");
        }
        public override DataAdapter CreateAdapter(string command, DbConnection connection)
        {
            return new SqlDataAdapter(command, connection as SqlConnection);
        }
    }
    public class SqlHandler : SqlFactory
    {
        private static SqlHandler _instance;
        private SqlLiteFactory _sqlLiteFactory;
        private MSSqlFactory _msSqlFactory;
        //Singleton pattern.
        public static SqlHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SqlHandler();
                }
                return _instance;
            }
        }
        private SqlHandler()
        {
            _sqlLiteFactory = new SqlLiteFactory();
            _msSqlFactory = new MSSqlFactory();
        }
        public override DbConnection CreateConnection()
        {
            //Some code determining if better to use SqlLite or MS SQL.
            if (useSqlLite)
            {
                return _sqlLiteFactory.CreateConnection();
            }
            else
            {
                return _msSqlFactory.CreateConnection();
            }
        }
        public override DataAdapter CreateAdapter(string command, DbConnection connection)
        {
            //Some code determining if better to use SqlLite or MS SQL.
            if (useSqlLite)
            {
                return _sqlLiteFactory.CreateAdapter(command, connection);
            }
            else
            {
                return _msSqlFactory.CreateAdapter(command, connection);
            }
        }
    }
