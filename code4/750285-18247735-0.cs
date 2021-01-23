    string connstring = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
    // change this select statement based on your exact column names 
    string insertstring = "insert into JobRegisteration ([Name] ,[User] ,[Password] ,[Email] ,[Phone],[Address] ,[City] ,[Gender] ,[Dob] ,[Qualification] ,[Skills]) values (@name ,@user ,@password ,@email ,@phone,@address ,@city ,@gender ,@dob ,@qualification ,@skills)";
               
    using (var con = new SqlConnection(connstring))
    using(var cmd = new SqlCommand(insertstring, con))
    {
        cmd.Parameters.AddWithValue("@name", txtName.Text);
        cmd.Parameters.AddWithValue("@user", txtUser.Text);
        // give all the parameters..
        con.Open();
        cmd.ExecuteNonQuery();
    }
