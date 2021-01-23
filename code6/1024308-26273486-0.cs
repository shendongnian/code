    private void MyDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
            {
                if (sender != null)
                {
                    DataGrid grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                    {
    
                            var selectedRow = grid.SelectedItem as MyObject;
    
                            try
                            {
                                Mouse.OverrideCursor = Cursors.Wait;
    
                                //TODO YOUR OPERATION ON selectdRow
                            }
                            finally
                            {
                                 Mouse.OverrideCursor = null;
                            }
    
                    }
                }
            }
