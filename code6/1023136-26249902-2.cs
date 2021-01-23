    private void dataGrid1_EditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        DataRowView drv = (DataRowView)dataGrid1.CurrentItem;
        if (drv.Row[3, DataRowVersion.Original] != drv.Row[3])
        {
           rowView.Row.SetField(4, /* my logic here */);
        }
    }
