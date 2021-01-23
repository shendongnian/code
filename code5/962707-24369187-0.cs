        private static void fillRows(List<String> columnList, String SOURCE_TABLE, String TARGET_TABLE, String COLUMN_NAME, String COLUMN_VALUE)
        {
            Console.WriteLine("Start filling");
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string selectSql = "SELECT " + COLUMN_NAME + "," + COLUMN_VALUE + " FROM " + SOURCE_TABLE;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSql, connection);
                    DataTable dataTable = new DataTable("cache");
                    dataAdapter.Fill(dataTable);
                    //Set ID
                    int ID = 1;
                    string insertSql = "INSERT INTO " + TARGET_TABLE + " VALUES ('" + ID + "',";
                    StringBuilder sbInsertSQL = new StringBuilder();
                    sbInsertSQL.Append(insertSql);
                    
                    int count = 0;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (count == columnList.Count)
                        {
                            count = 0;
                            sbInsertSQL.Length--; //remove ','
                            sbInsertSQL.Append(");"); //complete command
                            SqlCommand sqlCmd = new SqlCommand(sbInsertSQL.ToString(), connection);
                            sqlCmd.ExecuteNonQuery(); //Insert row
                            //reset 
                            sbInsertSQL.Clear();
                            ID++;
                            sbInsertSQL.Append("INSERT INTO " + TARGET_TABLE + " VALUES ('" + ID + "',");
                        }
                        //make sure, connecting correct
                        if (row[0].ToString().Equals(columnList[count].Split('#')[0])) //split off the unit
                        {
                            sbInsertSQL.Append("'" + tools.withoutUnit(row[1].ToString()) + "',");
                            count++;
                        }      
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
