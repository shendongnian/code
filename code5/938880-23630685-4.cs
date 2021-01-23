    //...
    myDataGrid1.KeyDown += myDataGrid1_KeyDown;
    //...
    void myDataGrid1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key == System.Windows.Input.Key.Enter)
        {
            var cell = myDataGrid1.SelectedCells[0];
            TextBlock cellContent = cell.Column.GetCellContent(cell.Item) as TextBlock;
            if (cellContent != null)
            {
                if (String.IsNullOrWhitespace(cellContent.Text))
                    button.Focus();
            }
        }
    }
