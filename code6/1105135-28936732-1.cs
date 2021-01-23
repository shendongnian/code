    SqlConnection conn=new SqlConnection("your DB connection string"); //connect to the database here
    conn.Open();
    SqlDataAdapter sda=new SqlDataAdapter("SELECT SUM(Amount) FROM sample",conn);
    conn.Close();
    DataTable dt= new DataTable();
    sda.Fill(dt);
    lblsupcount.Text=dt.Rows[0][0].toString();
