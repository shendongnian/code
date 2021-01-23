     List<string> lastNames = new List<string>();
     using(SqlCeDataReader dr = mCommand.ExecuteReader())
     {
         while(dr.Read())
         {
             string lastName = (string)dr["LastName"];
             
             lastNames.Add(lastName);
         }
     }
