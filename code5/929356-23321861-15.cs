    ITreeNode root = new TreeNode(
    new TreeNode(new TreeLeaf(3), new TreeLeaf(4)),
    new TreeNode(new TreeLeaf(2),
        new TreeNode(new TreeLeaf(7), new TreeLeaf(3)))
    );
    var visitor = new DepthTreeVisitor();
    root.Accept(visitor);
    visitor.Depth.Should().Be(3);
