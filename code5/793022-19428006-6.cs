    Paths = new ObservableCollection<Path>();
    var p1 = new Path { Name = "Folder 1", IsLeaf = false , Children = new ObservableCollection<Path>() };
    var p11 = new Path { Name = "Item 1-1", IsLeaf = true, Children = new ObservableCollection<Path>() };
    var p12 = new Path { Name = "Item 1-2", IsLeaf = true, Children = new ObservableCollection<Path>() };
    var p13 = new Path { Name = "Folder 1-3", IsLeaf = false, Children = new ObservableCollection<Path>() };
    var p131 = new Path { Name = "Item 1-3-1", IsLeaf = true, Children = new ObservableCollection<Path>() };
    // Build path's
    p13.Children.Add(p131);
    p1.Children.Add(p11);
    p1.Children.Add(p12);
    p1.Children.Add(p13);
    Paths.Add(p1);
