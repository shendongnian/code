    private void gridView1_CustomRowFilter(object sender, RowFilterEventArgs e)
    {    
        if (e.ListSourceRow == rowIndex)
        {
            e.Visible = true;
            e.Handled = true;
        }
    }
