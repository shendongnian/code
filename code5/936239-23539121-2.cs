    DataView contactsView;
    
    private void Form2_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            var da = new SqlDataAdapter("SELECT * FROM from contactsinfo", conn);
            da.Fill(dt);
        }
    
        contactsView = dt.AsDataView();
        dataGridView1.DataSource = contactsView;    
    }
