        SqlConnection con = new SqlConnection(@"Data Source=BG9;Initial Catalog=Northwind;Integrated Security=True");
        con.Open();
        SqlDataAdapter ad1 = new SqlDataAdapter();
        ad1.InsertCommand = new SqlCommand("insert into test_date values (CONVERT(VARCHAR(10),'" + TextBox1.Text+"',120))", con);
        ad1.InsertCommand.ExecuteNonQuery();
        con.Close();
      
