    string Database = "Name Of Database";
    SqlConnection Con = new SqlConnection("Data Source=SqlServerName; Initial Catalog=" + Database + ";Integrated Security=True");
    SqlCommand Cmd = new SqlCommand("SELECT * FROM TableName", Con);
    
    DataTable Table = new DataTable();
    SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
    Adapter.Fill(Table);
    
    Grid.DataSource = Table;
    Grid.DataBind();
