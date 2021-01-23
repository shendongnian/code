    private void Form1_Load(object sender, EventArgs e)
                {
                    string connectionstring = @"Data Source=|DataDirectory|\Database1.sdf";
                    SqlCeConnection connection = new SqlCeConnection(connectionstring);
                    SqlCeCommand command = new SqlCeCommand(" SELECT * FROM journalTbl ORDER BY journalId DESC ;", connection);
                    try
                    {
                        SqlCeDataAdapter adapter = new SqlCeDataAdapter();
                        adapter.SelectCommand = command;
                        DataTable datatable = new DataTable();
                        adapter.Fill(datatable);
                        BindingSource bindingsource = new BindingSource();
        
                        bindingsource.DataSource = datatable;
                        dataGridView1.DataSource = bindingsource;
                        adapter.Update(datatable);
                    }
        
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    
    
    }
    
    
    
    
            }       
