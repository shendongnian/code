    // In C# I'd rather start the public method with the capital letter "U" 
    // unlike it in Java where "updateProjectData" is more popular
    public void UpdateProjectData(ProjectsEvent message) {
      // Put "using" when working with IDisposable instances
      // Is long "update_connection" really more readable than "conn" for connection?
      using (MySqlConnection conn = new MySqlConnection("server=localhost;database=my_project;port=3306;uid=root;password=;AutoEnlist=false")) {
        conn.Open();
    
        // Once again, put "using" on IDisposable instances
        // command1 doesn't look very good: what's "1" here?
        // "command" looks more naturally
        using (MySqlCommand command = conn.CreateCommand()) {
          // Why don't you format your query out?
          command.CommandText = 
            "update `my_project`.`projekte`\n" +
            "   set `desc` = @prm_desc\n" +
            " where `projekte`.`ID` = @prm_projekte_id";
    
          // Beware SQL injection! Use bind variables
          command.Parameters.AddWithValue("@prm_desc", message.prj_description);
          command.Parameters.AddWithValue("@prm_projekte_id", message.RecordID);
    
          command.ExecuteNonQuery();
        }
      }
    }
    // finally: this construction is totally useless: you're catching 
    // exception, do nothing and throw unchanged exception again -
    // why on earth bother to catch it?
    // try {
    //   ...
    // }
    // catch (Exception e) {
    //   throw e;
    // } 
