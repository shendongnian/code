    private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedIndex != -1)
            {
                DataGrid dataGrid = sender as DataGrid;
                DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex);
                DataGridCell RowColumn = dg.Columns[0].GetCellContent(row).Parent as DataGridCell;
                btn.Content = ((TextBlock)RowColumn.Content).Text;
            }
        }
    dg = your datagrid 
    dg.Columns[0] = change 0 into what column you want
    info from btn.Content = what you want the content to be
