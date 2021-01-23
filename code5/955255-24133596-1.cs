    private void dataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
    {
        DataGridView gridView = sender as DataGridView;
        if (gridview !=null)
        {
            gridView.Rows[0].HeaderCell.Value = string.format("Total Number of Rows:  {0}",gridview .Rows.Count);
        }
    }
  
