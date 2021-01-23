    using (SqlConnection con = new SqlConnection("connection string")) 
    using(SqlCommand cmd = new SqlCommand("SELECT EmpName FROM Employee WHERE EmpID=@EmpID", con))
    {
        cmd.Parameters.AddWithValue("@EmpID", id.Text);
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        //..... your rest of the code
    }
