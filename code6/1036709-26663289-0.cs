    public static IEnumerable<Node> TraverseTree(this Node root, CancellationToken token)
    {
        if (root.Children != null)
        {
            foreach (var child in root.Children)
            {
                var nodes = TraverseTree(child);
                foreach (var node in nodes)
                {
                    yield return node;
                    if (token.IsCancellationRequested) return; //cancel if requested.
                }
            }
        }
        yield return root;
    }     
