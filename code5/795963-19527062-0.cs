    using (SqlConnection con = new SqlConnection(Dal.GetConnectionString("CONNECTIONSTRING")))
    {
        SqlDataAdapter adap = new SqlDataAdapter();
        adap.UpdateCommand = new SqlCommand(Update, con);
        // ...
        adap.Update(newTable);
    }
