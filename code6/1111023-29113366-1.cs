            IEnumerable<TModel> result;
            using (MySqlConnection conn = new MySqlConnection(_mysqlConnString))
            {
                // "Query" is a Dapper extension method that stuffs the datareader into objects based on the column names
                result = conn.Query<TModel>("Select * from YourTable");
            }
            // do stuff with result
