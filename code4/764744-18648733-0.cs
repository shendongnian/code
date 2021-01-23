    Dictionary<string, List<Node>> children = null; 
    List<Node> result = null;
    
    private void GetSortedList()
    {
        var ie = data;
        children = new Dictionary<string,List<Node>>();
        // construct the dictionary 
        foreach (var n in ie) 
        {
            if (!children.ContainsKey(n.ParentId)) 
            {
                children[n.ParentId] =  new List<Node>();
            }
            children[n.ParentId].Add(n);
        }
        // Depth first traversal
        result = new List<Node>();
        DepthFirstTraversal("", 1);
        if (result.Count() !=  ie.Count()) 
        {
            // If there are cycles, some nodes cannot be reached from the root,
            // and therefore will not be contained in the result. 
            throw new Exception("Original list of nodes contains cycles");
        }
    }
    private void DepthFirstTraversal(string parentId, int depth)
    {
        if (children.ContainsKey(parentId))
        {
            foreach (var child in children[parentId])
            {
                child.Depth = depth;
                result.Add(child);
                DepthFirstTraversal(child.Id, depth + 1);
            }
        }
    }
  
