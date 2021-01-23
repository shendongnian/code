    private void Treeview1_MouseRightButtonDown(object sender, MouseButtonEventArgs e){
        // The source from the Mouse Event Args is a TreeViewItem.
        var treeViewitem = e.Source as TreeViewItem;
            
        // Than works your Code in the above Posts!
        if (treeViewitem != null)
        {
            treeViewitem.IsSelected = true;
            e.Handled = true;
        }
    }
