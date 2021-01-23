    // Takes a work status and returns the appropriate graph.
    static GenericBaseGraphClass GetGraph(WorkStatus input)
    {
        select(input.Status)
        {
            // Concrete derived classes go here.
        }
    }
    // Test data.
    var someWork = new List<WorkStatus>()
    {
        new SecondStatus(),
        new FirstStatus()
    };
    // Sort it.
    var sortedWork = someWork.Sort((x,y) => x.Status > y.Status);
    // Get your object graphs.
    var objectGraphs = sortedWork.Select(x => GetGraph(x.Status))
    
