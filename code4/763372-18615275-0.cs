    // Version 7 code, untested
    var treeProvider = new TreeProvider();
    var childNodeId = 1;
    
    // Get the child Node
    // Node ID, Culture, Site name
    var childNodeDataSet = treeProvider.SelectNodes(childNodeId, null, CMSContext.CurrentSiteName);
    
    if (childNodeDataSet.Items.Any())
    {
        // Assuming the child node was found, get the parent ID
        var parentNodeId = childNodeDataSet.Items[0].NodeParentID;
        
        // Now get the children of the parent, aka the siblings
        // Site name, Culture, Combine with default culture, Where clause, Order by clause
        var siblingNodes = treeProvider.SelectNodes(CMSContext.CurrentSiteName, "/%", null, false, null, "NodeParentID = '" + parentNodeId + "'", null);
    }
