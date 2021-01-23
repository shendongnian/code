    private void ToDoList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        TreeViewItem selItem = ((TreeViewItem)ToDoList.SelectedItem);
        //If the parent is a treeviewitem, this is a child node.
        if (selItem.Parent is TreeViewItem)
        {
            //Check if the parent treeviewitem is the standards node.
            if (((TreeViewItem)selItem.Parent).Header.ToString() == "Standards")
            {
                //Do stuff here.
            }
        }
    }
