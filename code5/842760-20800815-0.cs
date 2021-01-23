    private void Grid1_SelectedCellsChanged(object sender,
                                            SelectedCellsChangedEventArgs e)
    {
        DataGrid dg = (DataGrid)sender;
        foreach (var item in e.AddedCells)
        {
            DataGridRow row = 
               (DataGridRow)dg.ItemContainerGenerator.ContainerFromItem(item.Item);
                    
            var col = item.Column as DataGridColumn;
    
            MessageBox.Show("" + col.Header);
    
            var fc = col.GetCellContent(item.Item);
            if (fc is TextBlock)
            {
                MessageBox.Show("Values" + (fc as TextBlock).Text);
            }
    
            MessageBox.Show("Row Header " + row.Header.ToString());
        }
    }
