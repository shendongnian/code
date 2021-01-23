    RadTreeViewItem parent1 = new RadTreeViewItem {
        Header = NodeHeader(item.Path, item.Name, SelectedPath, ProjectData),
        Tag = item
    };
    foreach (var child in item.Children)
    {
        parent1.Items.Add(new RadTreeViewItem {
            Header = NodeHeader(child.Path, child.Name, SelectedPath, ProjectData),
            Tag = child
        });
    }
    Parent.Items.Add(parent1);
