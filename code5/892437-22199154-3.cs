    object column1 = "";
    object column2 = "";
    foreach (DataGridViewRow row in dataGridView2.Rows)
    {
        if(!item.IsNewRow)
        {
            column1 = item.Cells["dataGridViewTextBoxColumn1"].Value;
            column2 = item.Cells["dataGridViewTextBoxColumn2"].Value;
            mailItem.Body += column2 != null ? column2.ToString() : "" + " - " +
                             column1 != null ? column1.ToString() : "" + "\n";
    }
