    foreach (object item in treeView1.Items) {
      //cls.Node n=(cls.Node)item;
      //n.IsSelected = true;               
      var tvItem = treeView1.ItemContainerGenerator.ContainerFromItem(item) 
                   as TreeViewItem;
      if(tvItem != null) tvItem.Background = Brushes.Blue;//just an example
    }
