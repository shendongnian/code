    using (var con =new SqlConnection(yourConnectionString))
    {
        SqlCommand cmd = new SqlCommand("insert into TestTable values('@firstName', '@lastName')", con);
        SqlParameter paramFirstName= new SqlParameter();
        paramFirstName.ParameterName = "@firstName";
        paramFirstName.Value         = firstName;
        SqlParameter paramLastName= new SqlParameter();
        paramLastName.ParameterName = "@lastName";
        paramLastName.Value         = lastName;
        cmd.Parameters.Add(paramFirstName);
        cmd.Parameters.Add(paramLastName);
        con.Open();
        cmd.ExecuteNonQuery();
    }
