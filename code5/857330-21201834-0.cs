    protected void btn_Click(object sender, EventArgs e)
    {
        ImageButton button = sender as ImageButton;
        TableCell cell = button.Parent as TableCell;
        TableRow row = cell.Parent as TableRow;
        int index = table1.Rows.GetRowIndex(row);
    }
