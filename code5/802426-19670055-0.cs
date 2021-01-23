    public Dictionary<string, string> Select(string table, string WHERE, MySqlParameter[] prms)
    {
    
       string query = "SELECT * FROM " + table + " WHERE " + WHERE + "";
    
       Dictionary<string, string> selectResult = new Dictionary<string, string>();
    
       if (this.Open())
       {
          MySqlCommand cmd = new MySqlCommand(query, conn);
          cmd.Parameters.AddRange(prms);
          MySqlDataReader dataReader = cmd.ExecuteReader();
          try
          {
             while (dataReader.Read())
             {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                   selectResult.Add(dataReader.GetName(i).ToString(), dataReader.GetValue(i).ToString());
                }
             }
             dataReader.Close();
          }
          catch { }
          this.Close();
          return selectResult;
       }
       else
       {
          return selectResult;
       }
    }  
