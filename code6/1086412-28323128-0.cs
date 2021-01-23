          List<Object[]> results = new List<Object[]>();
    
          using (SqlConnection conn = new SqlConnection("Your connection String")) {
            conn.Open();
    
            using (SqlCommand query = new SqlCommand("your query", conn)) {
              //TODO: May be you have parameters - assign them here...
              using (var reader = query.ExecuteReader()) {
                while (reader.Read()) {
                  results.Add(new Object[] {reader.GetValue(0), reader.GetValue(1)});
                }
              }
            }
          }
    
          data = results.ToArray(); 
