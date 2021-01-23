    private void BindEmpGrid(Int32 empId)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter();
        try
        {
             SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["database1ConnectionString"].ConnectionString);
             SqlCommand cmd1 = new SqlCommand("select *  from Emp_Tb where Emp_Id=@id", con);
             cmd1.Parameters.AddWithValue("@id",empId );
             adp.SelectCommand = cmd1;
             adp.Fill(dt);
