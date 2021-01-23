        private static void ExecuteSqlCommand(DbContext dbContext, string sql, params object[] sqlParameters)
        {
            try
            {
                if (dbContext.Database.Connection.State == ConnectionState.Closed)
                    dbContext.Database.Connection.Open();
                var cmd = dbContext.Database.Connection.CreateCommand();
                cmd.CommandText = sql;
                foreach (var param in sqlParameters)
                    cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
