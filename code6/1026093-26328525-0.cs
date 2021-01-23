    class SqlQueries
    {
        private SqlConnection connection;
        public bool Connect()
        {
            Try {
                connection = ...
                connection.Open();
                return true;
            } catch {
                return false;
            }
        }
        ....
    }
    class CommandLineInterpreter 
    {
        public void Run()
        {
            var sqlQueries = new SqlQueries();
            if (sqlQueries.Connect()) {
                Console.WriteLine("connected");
                // run your interpreter here
                ...
            } else {
                Console.WriteLine("Connection error! Not connected.");
            }
        }
    }
