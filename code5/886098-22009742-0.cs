    for (i = 0; i < registry_path_list.Count; i++)
    {
        treeViewList.Add(new TreeViewItem()
        {
            ParentID = 0,
            ID = 0,
            Text = registry_path_list[i]
        });
    }
