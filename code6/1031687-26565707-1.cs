    public static T ReplaceNodes<T>(
        this T root, IReadOnlyList<SyntaxNode> oldNodes, SyntaxNode newNode)
        where T : SyntaxNode
    {
        if (oldNodes.Count == 0)
            throw new ArgumentException();
        var newRoot = root.TrackNodes(oldNodes);
        var first = newRoot.GetCurrentNode(oldNodes[0]);
        newRoot = newRoot.ReplaceNode(first, newNode);
        var toRemove = oldNodes.Skip(1).Select(newRoot.GetCurrentNode);
        newRoot = newRoot.RemoveNodes(toRemove, SyntaxRemoveOptions.KeepNoTrivia);
        return newRoot;
    }
