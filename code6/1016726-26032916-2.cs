    class WorkItem
    {
        public CustomObject Object { get; private set; }
        public CustomTask Task { get; private set; }
        public void Execute()
        {
            // Perform {Task} on {Object}.
        }
    }
...
    // Pseudo-code - for actual implementation see the final solution.
    WorkItem[] workItems = ...
    var workItemGroups = workItems.GroupBy(i => new { i.Object, i.Task });
    Parallel.ForEach(workItemGroups, workItemGroup =>
    {
        foreach (WorkItem workItem in workItemGroup)
        {
            workItem.Execute();
        }
    });
