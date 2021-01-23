    public override IEnumerable<TreeNode> ComputeNodeChildren()
    {
        var mapPerNode = generateMapPerNode();
        var scoreFn = HeuristicManager.Instance.GetScore;
        foreach (var map in mapPerNode)
            yield return new TreeNode(map.Item1, map.Item2, scoreFn);
    }
