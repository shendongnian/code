            using (OleDbConnection cn = new OleDbConnection(connectionString))
            {
                cn.Open();
                using (OleDbCommand cmd1 = new OleDbCommand("INSERT INTO [MySheet] (COLUMN1, COLUMN2) VALUES ('Count', 1);", cn))
                {
                    cmd1.ExecuteNonQuery();
                }
                using (OleDbCommand cmd1 = new OleDbCommand("UPDATE [MySheet$] SET COLUMN2 = 5 WHERE COLUMN1 = 'Count'", cn))
                {
                    cmd1.ExecuteNonQuery();
                }
            }
