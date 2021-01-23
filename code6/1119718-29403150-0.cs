            string[] tasks;
            string sql = "SELECT [Task Name] FROM Tasks";
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                using (OleDbDataReader dataReader = cmd.ExecuteReader())
                {
                    List<object[]> list = new List<object[]>();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            object[] oarray = new object[dataReader.FieldCount];
                            list.Add(oarray);
                            for (int i = 1; i <= dataReader.FieldCount; i++)
                            {
                                oarray[i] = dataReader[i];
                            }
                        }
                    }
                }
            }
