	public static WorkItem GetWorkItem(int workItemId)
	{			
		Uri tfsUri = new Uri("http://mytfsserver:8080/tfs");
		TfsTeamProjectCollection tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(tfsUri);
		WorkItemStore workItemStore = tfs.GetService<WorkItemStore>();
		return workItemStore.GetWorkItem(workItemId);
	}
    public static void PrintRevisions(int workItemId)
	{
		WorkItem wi = GetWorkItem(workItemId);
    
		foreach (Revision revision in wi.Revisions)
		{
			Console.WriteLine("Revision {0}", revision.Fields["Rev"].Value);
			string assignedTo = revision.Fields["Assigned To"].Value.ToString();
			string changedDate = revision.Fields["Changed Date"].Value.ToString();
			string changedBy = revision.Fields["Changed By"].Value.ToString();
    
			if (!string.IsNullOrEmpty(assignedTo))
				Console.WriteLine("Assigned To: {0} Date: {1} By: {2}", assignedTo, changedDate, changedBy);
    	}
    }
