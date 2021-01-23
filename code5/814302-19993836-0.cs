    var nodes = new List<Node>();
    // !! populate your nodes list with all your real nodes first!
    // filter to nodes with at most 1 parent and 1 child
    // group by a tuple containing the parent (if it exists) and the child (if it exists)
    var grouped = nodes.Where(i => i.Children.Count <= 1 && i.Parents.Count <= 1)
        .GroupBy(i => 
            new Tuple<Node, Node>(i.Parents.Count == 0 ? null : i.Parents[0], 
                                    i.Children.Count == 0 ? null : i.Children[0]));
    // go through your groups - each one should be a cluster of nodes to be merged
    foreach (var group in grouped)
    {
        var node = group.First();
                    
        // if this group has a parent
        if (node.Parents.Count == 1)
        {
            // change the parent to only have one child - this one!
            node.Parents[0].Children.Clear();
            node.Parents[0].Children.Add(node);
        }
        // if this group has a child
        if (node.Children.Count == 1)
        {
            // change the child to only have one parent - this one!
            node.Children[0].Parents.Clear();
            node.Children[0].Parents.Add(node);
        }
    }
