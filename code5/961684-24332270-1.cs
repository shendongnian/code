    DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(), false);
            int success = 0;
            using (var db = new DatabaseProviderFactory().Create("Dataconnectionstring"))
            {
                string sqlCommand = "";
                using (var dbCommand = db.GetStoredProcCommand(sqlCommand))
                {
                    dbCommand.CommandTimeout = 0;
                    try
                    {
                        success = Convert.ToInt32(db.ExecuteScalar(dbCommand));
                    }
                }
            }
        return success;
