    using(SqlConnection con=new SqlConnection(constring))
       {
          using(SqlCommand cmd=new SqlCommand(Query,con))
          {
           try
           {
              con.Open();
              return cmd.ExecuteNonQuery();
           }
           catch(Exception ex)
           {
              throw;
           }       
          }
       }
