    private void MyDataGrid_OnPreviewKeyDown(object sender, KeyEventArgs e)
    {
        var dg = sender as DataGrid;
       // alter this condition for whatever valid keys you want - avoid arrows/tab, etc.
        if (dg != null && !dg.IsReadOnly && e.Key == Key.Enter)
        {
            var cell = dg.GetSelectedCell();
            if (cell != null && cell.Column is DataGridTemplateColumn)
            {
                cell.Focus();
                dg.BeginEdit();                        
                e.Handled = true;
            }
        }
    }
