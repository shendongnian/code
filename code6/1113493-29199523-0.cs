    private void CreateTreeView()
    {
        var roots = Options.Select(z => z.Id)
            .Except(Options.SelectMany(z => z.GotoOptions.Select(x => x.GotoId)))
            .Select(z => Options.Single(x => x.Id == z));
        var treeNodes = roots.Select(GetNode);
        foreach (var treeNode in treeNodes)
        {
            pages.Nodes.Add(treeNode);
        }
    }
    private TreeNode GetNode(Option option)
    {
        var node = new TreeNode
        {
            Text = option.Title,
            Tag = option
        };
        
        foreach (var child in option.GotoOptions.Select(z => Options.Single(x => x.Id == z.GotoId)))
        {
            node.Nodes.Add(GetNode(child));
        }
        return node;
    }
