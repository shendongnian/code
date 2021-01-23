    private void MyDataGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Middle && e.ButtonState == MouseButtonState.Pressed)
        {
            MyDataGrid.Focus();
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            // Traverse the visual tree looking for DataGridCell
            while ((dep != null) && !(dep is DataGridCell))
                dep = VisualTreeHelper.GetParent(dep);
            if (dep == null)
            {
                // Didn't find DataGridCell
                return;
            }
            DataGridCell cell = dep as DataGridCell;
            if (cell != null)                
            {
                DataGridCellInfo cellInfo = new DataGridCellInfo(cell);
                if(!MyDataGrid.SelectedCells.Contains(cellInfo))
                {
                    // The cell is not already selected, add it to the selection
                    MyDataGrid.SelectedCells.Add(new DataGridCellInfo(cell));
                }
                else
                {
                    // Cell is already part of selection, remove it (same behaviour as ctrl+left click)
                    MyDataGrid.SelectedCells.Remove(cellInfo);
                }
            
            }
        } 
    }
