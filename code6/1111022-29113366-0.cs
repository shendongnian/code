            using (MySqlConnection conn = new MySqlConnection(_mysqlConnString))
            {
                // "Query" is a Dapper extension method that stuffs the datareader into objects based on the column names
                var result = conn.Query<TModel>("Select * from YourTable").AsQueryable();
            }
