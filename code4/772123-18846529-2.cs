    public ICollection<TreeNode<T>> GetAllNodes()
    {
        var allNodes = new List<TreeNode<T>>();
        var queue = new Queue<TreeNode<T>>();
        queue.Enqueue(this); // will include root node
        while (queue.Any())
        {
            var current = queue.Dequeue();
            allNodes.Add(current);
            foreach (var child in current._children)
                queue.Enqueue(child);
        }
        return allNodes;
    }
