    // Added to Node class:
    public int GetDepthRecursive()
    {
        return Parent == null ? 0 : (Parent.GetDepthRecursive() + 1);
    }
    // To parse the text file into a node tree:
    Node rootNode = new Node { Number = 0 }; // You need a node for all those zero nodes to hang off
    Node currentNode = rootNode;
    foreach (var row in rows)
    {
        rowDepth = row.StartingSpaces.Count(); // Use any method you want to count these spaces
        var rowNode = new Node { Number = int.Parse(row) };
        // The new row node is at the same or lower depth than us
        // Go back up the tree to find the right parent for it
        while (currentNode.GetDepthRecursive() > rowDepth)
        {
            currentNode = currentNode.Parent;
        }
        rowNode.Parent = currentNode;
        currentNode = rowNode;
    }
