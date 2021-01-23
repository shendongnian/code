    DataTable dataT;
    BindingSource bindS;
    
    using (SqlCeConnection yourConnection = new SqlCeConnection("Data Source=|DataDirectory|\\YourDatabase.sdf"))
    {
        dataT = new DataTable();
        bindS = new BindingSource();    
    
        string query = "SELECT * FROM table01";
        SqlCeDataAdapter dA = new SqlCeDataAdapter(query, yourConnection);
        SqlCeCommandBuilder cBuilder = new SqlCeCommandBuilder(dA);
        dA.Fill(dataT);
        
        bindS.DataSource = dataT;
        DataGridView1.DataSource = bindS;
    }
