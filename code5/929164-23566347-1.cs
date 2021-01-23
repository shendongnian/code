    private void dgwUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        var dgw = (DataGridView) sender;
        DataGridViewColumn column = dgw.Columns[e.ColumnIndex];
        DataGridViewRow row = dgw.Rows[e.RowIndex];
        if (column.DataPropertyName.Contains("."))
        {
            e.Value = BindingHelper.GetPropertyValue(row.DataBoundItem, column.DataPropertyName);
        }
    }
