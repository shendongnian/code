    using (SqlCeConnection con = new SqlCeConnection(connectionstring))
        {
           try{con.Open();}
           catch(Exception ex)
           {
             // database connection error. log/display ex. > return.
           }
           
           if(con.State==ConnectionState.Open)
           { 
             using (SqlCeCommand Query = new SqlCeCommand("INSERT INTO Registers " + "(usernames,passwords,emailid,telno) " + "VALUES (@usernames,@passwords,@emailid,@telno)", con))
             {
                Query.Parameters.AddWithValue("@usernames", usernames);
                Query.Parameters.AddWithValue("@passwords", passwords);
                Query.Parameters.AddWithValue("@emailid", emailid);
                Query.Parameters.AddWithValue("@telno", telno);
                try{
                    Query.ExecuteNonQuery();
                   }
                catch(Exception ex)
                   {
                      // database communication error. log/display ex
                   }
             }
               MessageBox.Show("QueryExecuted");
            }
            if(con.State==ConnectionState.Open)
            { 
               try{con.Close();}
               catch{}
             }
        }
