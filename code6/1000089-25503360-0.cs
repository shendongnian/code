    private void MouseOverEvent(object sender, MouseEventArgs e)
    {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
    
             // iteratively traverse the visual tree
             while ((dep != null) &&
                     !(dep is DataGridCell) &&
                     !(dep is DataGridColumnHeader))
             {
                dep = VisualTreeHelper.GetParent(dep);
             }
    
             if (dep == null)
                return;
    
             if (dep is DataGridColumnHeader)
             {
                DataGridColumnHeader columnHeader = dep as DataGridColumnHeader;
                // do something
             }
    
             if (dep is DataGridCell)
             {
                DataGridCell cell = dep as DataGridCell;
    
                // navigate further up the tree
                while ((dep != null) && !(dep is DataGridRow))
                {
                   dep = VisualTreeHelper.GetParent(dep);
                }
    
                DataGridRow row = dep as DataGridRow;
               //!!!!!!!!!!!!!* (Look below) !!!!!!!!!!!!!!!!!
    
             }
