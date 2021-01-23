     conn.Open();
     using (SqlDataReader reader = command.ExecuteReader())
     {
         while (reader != null && reader.Read())
         {
             dt.Load(reader);         
         }
     }
     foreach (var row in dt.AsEnumerable())
     {
         result.Add(row["Health Insurance NO"].ToString());
     }
