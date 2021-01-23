      private void UIElement_OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
            {
                var dep = (DependencyObject)e.OriginalSource;
                while ((dep != null) && !(dep is DataGridCell))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }
                if (dep == null) return;
    
                if (dep is DataGridCell)
                {
                    var cell = dep as DataGridCell;
                    cell.Focus();
    
                    while ((dep != null) && !(dep is DataGridRow))
                    {
                        dep = VisualTreeHelper.GetParent(dep);
                    }
                    var row = dep as DataGridRow;
                    dataGrid1.SelectedItem = row.DataContext;   
                }
            }
