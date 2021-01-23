    private void button2_Click(object sender, EventArgs e)
    {
     string connString = @"Server=localhost;Initial Catalog=Database2;User      id=***;Password=***;";`
              
    
    SqlConnection sqlConn = new SqlConnection(connString);
                        SqlConn.Open();
                        string sqlQuery = @"SELECT * from tableP";
                        SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        da.Fill(table);
                        DataGridView dgv = new DataGridView();
                        dgv.DataSource = new BindingSource(table, null);
        SqlConn.Close();
        
