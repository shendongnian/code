    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
    
    if (dataGridView1.SelectedRows.Count > 0)
    {
    
    DataRow selectedRow = ((DataRowView)this.dataGridView1.SelectedRows[0].DataBoundItem).Row;
    
    DataTable dt = dsLocal.Tables[0].Clone();
    
    dt.ImportRow(selectedRow);
    
    ultraGrid1.DataSource = dt;
    ultraGrid1.DataMember = "";
    
    }
    }
