    var id2node = new Dictionary<int, TreeNode>();
    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
    {
        var node = new TreeNode();
        node.Text = ds.Tables[0].Rows[i]["catname"];
        node.Tag = ds.Tables[0].Rows[i]["parentid"];
        id2node.Add(ds.Tables[0].Rows[i]["catid"], node);
    }
    foreach (var node in id2node.Values)
    {
        TreeNode parent = null;
        if (id2node.TryGetValue((int)node.Tag, out parent))
        {
            parent.ChildNodes.Add(node);
        }
        else
        {
            trview.Nodes.Add(node);
        }
    }
