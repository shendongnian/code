    Using (SqlConnection con = database.GetConnection())
       {
         con.Open();
         Using (SqlCommand command = new SqlCommand("sqlhere"))
           {
             Using (SqlTransaction myTransaction = con.BeginTransaction())
                 {
                   //your code here
                 }
           }
       }  
