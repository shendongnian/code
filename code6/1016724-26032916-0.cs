    class WorkItem
    {
        public CustomObject Object { get; private set; }
        public CustomTask Task { get; private set; }
        public void Execute()
        {
        }
    }
...
    WorkItem[][] workItemGroups = workItems
        .GroupBy(i => new { i.Object, i.Task }, (key, group) => group.ToArray())
        .ToArray();
    Parallel.ForEach(workItemGroups, workItemGroup =>
    {
        foreach (WorkItem workItem in workItemGroup)
        {
            workItem.Execute();
        }
    });
