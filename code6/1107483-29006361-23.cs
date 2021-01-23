    private void DGV_SelectionChanged(object sender, EventArgs e)
    {
        if (selectedRow != null) selectedRow.Height = normalRowHeight;
        if (DGV.SelectedRows.Count <= 0)
        {
            selectedRow = null;
            display.Hide();
            return;
        }
        // assuming multiselect = false
        selectedRow = DGV.SelectedRows[0];
        // assuming ColumnHeader show with the same height as the rows
        int y = (selectedRow.Index + 1) * normalRowHeight;
        display.Location = new Point(1, y);
        // filling out the whole width of the DGV.
        // maybe you need more, if the DGV is scrolling horizontally
        // or less if you show a vertical scrollbar.. 
        display.Width = DGV.ClientSize.Width;
        // make room for the display object
        selectedRow.Height = display.Height;
        // tell it to display our row data
        display.displayRowData(selectedRow);
        // show the display
        display.Show();
    }
    private void DGV_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
    {
        // enforce refresh on the display
        display.Refresh();
    }
