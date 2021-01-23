    using (SqlCeConnection con = new SqlCeConnection())
       {
       con.ConnectionString = connectionString;
       con.Open();
       SqlCeCommand com = new SqlCeCommand("SELECT S_no,Name,Father_Name")
       SqlCeDataAdapter sda = new SqlCeDataAdapter(com);
       System.Data.DataTable dt = new System.Data.DataTable();
       sda.Fill(dt);
       dataGrid1.ItemsSource = dt.DefaultView;
       dataGrid1.AutoGenerateColumns = true;
       dataGrid1.CanUserAddRows = false;
       }
