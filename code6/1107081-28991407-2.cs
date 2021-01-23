    public override IEnumerable<TreeNode> ComputeNodeChildren()
    {
        var scoreFn = HeuristicManager.Instance.GetScore;
        return generateMapPerNode().Select(map => new TreeNode(map.Item1,
                                                               map.Item2, scoreFn));
    }
