            try
            {
                using(var conn = new SqlConnection(ConnectionString))
                using(var command = new SqlCommand(
                        @"ALTER TABLE dbo.tTest ADD NewColumn int NULL;
                        ALTER TABLE dbo.tTest SET (LOCK_ESCALATION = TABLE);", conn))
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
