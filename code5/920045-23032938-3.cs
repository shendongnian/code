            var db = DatabaseFactory.CreateDatabase(GlobalConstants.DBConnection);
            using (var cmd = db.GetStoredProcCommand("SprocName", parameterA, parameterB, parameterC))
            {
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        return dr.GetInt32(0);
                    }
                }
            }
