    void AddTreeViewItem()
    {
        TreeView t = new TreeView();
        TreeViewItem treeItem = new TreeViewItem();
        t.Items.Add(treeItem);
        treeItem.Selected += DoSomethingHere;
    }
    
    private void DoSomethingHere(object sender, RoutedEventArgs e)
    {
        Console.WriteLine("Tree Item Selected");
    }
