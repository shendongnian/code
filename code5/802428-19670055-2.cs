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
              ......
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
