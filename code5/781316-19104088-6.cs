    private static int NextGeneration = 0;
    public int Generation { get; private set; }
    public int GetClusterSize()
    {
        return GetClusterSizeInternal(NextGeneration++);
    }
    private int GetClusterSizeInternal(int target)
    {
        if (State != 1) return 0;
        Generation = target;
        int sum = 0;
        foreach (var neigh in InputNeigh)
        {
            if (neigh.State == 1 && neigh.Generation != target)
            {
                sum += neigh.GetClusterSizeInternal(target);
            }
        }
        return sum;
    }
