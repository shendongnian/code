    //add new method
    private void DeleteDictionaryEntries(TreeNode tn)
    {
        foreach(TreeNode child in tn.Nodes)
           DeleteDictionaryEntries(child);
        dictionary.Remove((string)tn.Tag);
    }
    
    //in your method
    DeleteDictionaryEntries(treeView.SelectedNode);
    treeView.Nodes.Remove(treeView.SelectedNode); // remove the selected node itself
