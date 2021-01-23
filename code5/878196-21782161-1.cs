     using(SqlConnection con = new SqlConnection(@"Data Source=KIMBERLY\SQLSERVER02;Initial     Catalog=Chalegh;User ID=***;Password=***"))
     {
       using(SqlCommand cmd = new SqlCommand("insert into TestTable values(@firstname,@lastname)", con))
       {
         con.Open();
         int status = cmd.ExecuteNonQuery();
         if(status>0)
            return "True";
        
            return "False";
        }
      }
