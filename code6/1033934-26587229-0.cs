    public IEnumerable<string> GetTagPaths (TreeView tv) { return GetTagPaths(tv.Nodes[0]); }
    public IEnumerable<string> GetFullPaths (TreeView tv){ return GetFullPaths(tv.Nodes[0]); }
    public IEnumerable<string> GetTagPaths (TreeNode node)
    {
      if (node.Tag == null || String.IsNullOrEmpty(node.Tag as string))
        node.Tag = node.Text;
      foreach (TreeNode child in node.Nodes)
      {
        child.Tag = (node.Tag as string) + "->" + child.Text;
        if (child.IsLeaf())
          yield return (child.Tag as string);
        else
          foreach (string childPath in GetTagPaths(child))
            yield return childPath;
      }      
    }
    public IEnumerable<string> GetFullPaths (TreeNode node)
    {
      if (node.IsLeaf())
          yield return node.FullPath;
      else
        foreach (TreeNode child in node.Nodes)
        {
          foreach (string childPath in GetFullPaths(child))
            yield return childPath;  
        }      
    }
