    using (SqlConnection con = new SqlConnection("Your connection string"))
    {
        con.Open();
        SqlCommand mycommand = new SqlCommand();
        mycommand.Connection = con;
        mycommand.CommandText = dbo.AddNewDoctor;
        mycommand.CommandType = CommandType.StoredProcedure;
                      
        mycommand.Parameters.AddWithValue(doctorName, email, password, ref DocId, ref result);
       
        mycommand.ExecuteNonQuery();
    }
