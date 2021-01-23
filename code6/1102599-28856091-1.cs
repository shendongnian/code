    try
       { testcon.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=dBtestDataSet;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        
        //open the connection       
        testcon.Open();
        MessageBox.Show("on");
        testcon.Close();
        MessageBox.Show("off"); }
    catch(Exception ex)
    {
        Debug.Write(ex.ToString());
    }
