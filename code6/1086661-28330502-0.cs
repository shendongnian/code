    List<Question> visited = new List<Question>();
    
    public static IEnumerable<T> Traversal<T>(
        T root,
        Func<T, IEnumerable<T>> getChildren)
    {
        if (root == null)
        {
            yield break;
        }
    
        //We visited this node!
        visited.Add(root);
    
        yield return root;
    
        var children = getChildren(root);
        if (children == null)
        {
            yield break;
        }
    
        //Don't re-visit nodes we have seen before!
        foreach (var child in children.Except(visited))
        {
            foreach (var node in Traversal(child, getChildren))
            {
                yield return node;
            }
        }
    }
