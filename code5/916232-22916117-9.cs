      foreach (var table in dataSet.Tables)
       {
           foreach (var row in table.Rows)
            {
                foreach (var column in table.Columns)
                {
                    var UserName= row["UserName"];            
                }
            }
         }
