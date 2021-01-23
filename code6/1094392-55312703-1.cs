    conn1 = JdbcConn.getConn();
              
                try
                {
                  
                    conn1.Open();
    
                    String sqllogin = "Select *from tbladdpattern  ";
                    var cmd = new MySqlCommand(sqllogin, conn1);//This is sql query execute
                    var reader = cmd.ExecuteReader();//Execute query
    
                    IList<string> listName = new List<string>();
                    while (reader.Read())
                    {
                        listName.Add(reader[1].ToString());
                    }
                   // listName = listName.Distinct().ToList();
                    comboBox1.DataSource = listName.Distinct().ToList();
    
    
                   
                    conn1.Close();//Close DataBase Connection
                }
                catch (Exception ex)
                {
                    conn1.Close();
                    LogCreate.WriteLog("Errorn in show all pattern " + ex);
                }
