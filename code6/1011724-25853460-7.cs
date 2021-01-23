    private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
    {
       cbx_Build.Left = dataGridView1.Columns[BuildIndex].HeaderCell.ContentBounds.Left;
       cbx_Publish.Left = dataGridView1.Columns[PubIndex].HeaderCell.ContentBounds.Left;
    }
