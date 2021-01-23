    Dictionary<int, MyNode> nodesDict = new Dictionary<int, MyNode>();
    // add the parent node
    nodesDict.Add(1, new TreeNode{NodeData = new MyNode{ID=1, ParentID=0, SeqID=1, Name="Root"}});
    // now go through the original list of nodes
    foreach (var node in NodesList)
    {
        // If there is an entry for this node already in the dictionary,
        // then update its NodeData.
        // Otherwise create a new entry.
        var dictNode;
        if (nodesDict.TryGetValue(node.ID, out dictNode))
        {
            dictNode.NodeData = node;
        }
        else
        {
            // add this node to the dictionary
            TheTree.Add(node.ID, node);
        }
        // find this node's parent, and add the node to the child list
        // if the node's parent doesn't exist, add it
        MyNode parentNode;
        if (!nodesDict.TryGetValue(node.ParentID, out parentNode))
        {
            // Parent doesn't yet exist.
            // Create an entry for it.
            nodesDictAdd(node.ParentID, new TreeNode());
        }
        // Add this node to the parent's children
        parentNode.Children.Add(node);
    }
