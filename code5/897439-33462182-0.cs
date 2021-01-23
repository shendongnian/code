    /// <summary>
    /// In the case there is a column in the DataGridView
    /// named CompanyNameColumn
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cmdRemoveDataGridViewRow_Click(object sender, EventArgs e)
    {
        // make sure we have a row to work with
        if (!datagridInfoOrg.CurrentRow.IsNewRow)
        {
            // use this value for your query
            string KeyValue = datagridInfoOrg
                .CurrentRow
                .Cells["CompanyNameColumn"]
                .Value
                .ToString();
    
            if (!string.IsNullOrWhiteSpace(KeyValue))
            {
                // row index for current row
                // int rowIndex = datagridInfoOrg.CurrentCell.RowIndex;
    
                // do your delete and would suggest using a parameterized
                // query especially if there is a chance of embedded apostrophe
                // in the cell value
                datagridInfoOrg.Rows.Remove(datagridInfoOrg.CurrentRow);
            }
            else
            {
                // recovery code in the event the value in the cell
                // was not valid.
            }
        }
    }
