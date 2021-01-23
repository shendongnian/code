    DataTable x = new DataTable();
                x.Columns.Add("URL");
                x.Columns.Add("PAth");
                x.Columns.Add("Boolean");
    
                x.Rows.Add("A", "1", true);
            x.Rows.Add("B", "1" , false);
            x.Rows.Add("C", "1" , true);
            x.Rows.Add("D", "1" , true);
            x.Rows.Add("E", "1", true);
            x.Rows.Add("F", "1", true);
            x.Rows.Add("G", "1",true);
    
    dataGridView1.DataSource = x;
    
    
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var databaseRecordId = e.RowIndex;
            dataGridView1.Rows[e.RowIndex].Cells[2].Value = false;
        }
