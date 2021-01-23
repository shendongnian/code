        I am using below code for access current dateTime from system
       
        TextBox1.Text = DateTime.Now.ToString();  // This will give current dateTime of system.
        SqlConnection con = new SqlConnection(@"Data Source=BG9;Initial Catalog=Northwind;Integrated Security=True");
        con.Open();
        SqlDataAdapter ad1 = new SqlDataAdapter();
        ad1.InsertCommand = new SqlCommand("insert into test_date values ('"+TextBox1.Text+"')", con);
        ad1.InsertCommand.ExecuteNonQuery();
        con.Close();
      and txt_date value is 10/30/2014 10:22:07 AM and it inserted in database as 10/30/2014 10:22:07 AM
