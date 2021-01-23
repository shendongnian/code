    DataTable x = new DataTable();
                x.Columns.Add("URL");
                x.Columns.Add("PAth");
    
                x.Rows.Add("A", "1");
                x.Rows.Add("B", "1");
                x.Rows.Add("C", "1");
                x.Rows.Add("D", "1");
                x.Rows.Add("E", "1");
                x.Rows.Add("F", "1");
                x.Rows.Add("G", "1");
    
    dataGridView1.DataSource = x;
    
    
    private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
                var databaseRecordId = e.RowIndex;
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = 555;
    }
