     public static int ExecuteSQL(string sql)
     {
          using (var conn = DBUtility.GetOpenConnection()) 
          {
               ....
          }
     }
