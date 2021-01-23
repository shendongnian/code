    SqlConnection myConnection = new SqlConnection("Data Source=SHIRWANIPC;" + "Initial  Catalog=TEST DATABASE;" + "Integrated Security=True");
    myConnection.Open();
    SqlCommand objcmd = new SqlCommand("SELECT * FROM Customer", myConnection);
    //objcmd.ExecuteNonQuery();      
    SqlDataAdapter adp = new SqlDataAdapter(objcmd);
    DataTable dt = new DataTable();
    adp.Fill(dt);
    //MessageBox.Show(dt.ToString());
    dataGridView1.DataSource = dt;
