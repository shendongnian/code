          // I've used KeyValuePair for parameters; probably a specialized class will be better 
          public static DataTable SqlConnection(string query, params KeyValuePair<String, Object>[] parameters) {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString)) {
              using (SqlCommand cmd = cn.CreateCommand()) {
                cmd.CommandText = query;
    
                // Parameters, if they're mentioned 
                if (!Object.ReferenceEquals(null, parameters))
                  foreach (var prm in parameters)
                    cmd.Parameters.AddWithValue(prm.Key, prm.Value);
    
                using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                  cn.Open();
    
                  DataTable result = new DataTable();
    
                  da.Fill(result);
    
                  return result;
                }
              }
            }
          }
...
    DataTable dt1 = SqlConnection("select 123");
    DataTable dt2 = SqlConnection(
                       @"select * 
                          from MyTable 
                         where MyField = @MyParam", 
                       new KeyValuePair<String, Object>("@MyParam", 123));
