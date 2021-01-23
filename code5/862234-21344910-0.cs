    public void CollapseGroups(DataGridControl grid, IEnumerable<CollectionViewGroup> groups)
    {
        var to_process = new Stack<IEnumerable<CollectionViewGroup>>();
        to_process.Push(groups);
        do {
            groups = to_process.Pop();
            foreach (var @group in groups)
            {
                grid.CollapseGroup(@group);
                to_process.Push(@group.Items.OfType<CollectionViewGroup>());
            }
        } while (to_process.Count > 0);
    }
