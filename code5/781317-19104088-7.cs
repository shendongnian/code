    private static int NextGeneration = 0;
    public int Generation { get; private set; }
    public int GetClusterSize()
    {
        if (State != 1) return 0;
        int target = NextGeneration++;
        Stack<Node> stack = new Stack<Node>();
        stack.Push(this);
        int count = 0;
        while (stack.Count > 0)
        {
            Node node = stack.Pop();
            if (node.Generation == target) continue;
            node.Generation = target;
            count++;
            foreach (var neigh in node.InputNeigh)
            {
                if (neigh.State == 1 && neigh.Generation != target)
                {
                    stack.Push(neigh);
                }
            }
        }
        return count;
    }
