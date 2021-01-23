    public List<Issue> Load_Issues() {
      //TODO: Put actual connection string here
      using (SqlConnection con = new SqlConnection("Connection String here")) {
        con.Open();
    
        // Put IDisposable into using
        using (SqlCommand cmd = new SqlCommand()) {
          cmd.Connection = con;
          cmd.CommandText = "Get_All_Issue";
          cmd.CommandType = CommandType.StoredProcedure;
    
          List<Issue> ObjList = new List<Issue>();
    
          // Put IDisposable into using 
          using (var Sdr = cmd.ExecuteReader()) {
            while (Sdr.Read()) {
              //TODO: Pull out records from database into ObjList
            }
          } 
    
          return ObjList; 
        }
      }
    }
