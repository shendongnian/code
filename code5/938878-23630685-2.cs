    //...
    myDataGrid1.KeyDown += myDataGrid1_KeyDown;
    //...
    void myDataGrid1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key == System.Windows.Input.Key.Enter)
        {
            var cell = myDataGrid1.SelectedCells[0];
            string cellContent = cell.Column.GetCellContent(cell.Item);
            if (String.IsNullOrWhitespace(cellContent))
                button.Focus();
        }
    }
