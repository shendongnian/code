    public int GetClusterSize()
    {
        if (State != 1) return 0;
        List<Node> cluster = new List<Node>();
        Stack<Node> stack = new Stack<Node>();
        stack.Push(this);
        while (stack.Count > 0)
        {
            Node node = stack.Pop();
            if (node.Visited) continue;
            node.Visited = true;
            cluster.Add(node);
            foreach (var neigh in node.InputNeigh)
            {
                if (neigh.State == 1 && !neigh.Visited)
                {
                    stack.Push(neigh);
                }
            }
        }
        int clusterSize = cluster.Count;
        foreach (var node in cluster)
        {
            node.Visited = false;
        }
        return clusterSize;
    }
