    SqlConnection con = new SqlConnection();
    con.ConnectionString = @"Data Source=RITESH-PC\SQLEXPRESS;database=master;Integrated     Security=true";
    con.Open();
    SqlDataAdapter adp = new SqlDataAdapter("Select * from Employee2", con);
    SqlDataAdapter adp1 = new SqlDataAdapter("Select * from employee1", con);
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    adp.Fill(dt);
    adp1.Fill(dt1);
    //After merge u will get merge result in dt.
    dt.Merge(dt1);
