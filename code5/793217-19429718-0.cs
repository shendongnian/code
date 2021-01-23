    public class ChangeSet
    {
      IList<WorkItem> WorkItems {get;set;};
    }
    
    public class WorkItem
    {
      IList<ChangeSet> ChangeSets{get;set;};
    }
