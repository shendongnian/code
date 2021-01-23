    private void ChercheStextBox_TextChanged(object sender, EventArgs e)
        {
            var bd = (BindingSource)dataGridView3.DataSource;
            var dt = (DataTable)bd.DataSource;
            dt.DefaultView.RowFilter = string.Format("LibService like '%{0}%'", ChercheStextBox.Text.Trim().Replace("'", "''"));    
            dataGridView3.Refresh();
            
        }
