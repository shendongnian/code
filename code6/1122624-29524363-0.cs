    ParallelOptions Options = new ParallelOptions{MaxDegreeOfParallelism = 4};
    IList<Step> AllSteps;
    public void Execute()
    {
        var RemainingSteps = new HashSet<Step>(AllSteps);
        while(RemainingSteps.Count > 0)
        {
            var ExecutableSteps = RemainingSteps.Where(s => s.Parents.All(p => p.IsComplete)).ToList();
            Parallel.ForEach(ExecutableSteps, Options, ExecuteStep);
            RemainingSteps.ExceptWith(ExecutableSteps);
        }   
    }
