    TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(
        new Uri("http://server/tfs"));
    var workItemStore =  tpc.GetService<WorkItemStore>(); 
    WorkItemCollection queryResults = workItemStore.Query(
        "Select [State], [Title]  From WorkItems " + 
        " Where [Work Item Type] = 'Task' AND " + 
        " ([State] <> 'Resolved' AND [State] <> 'Closed') ");
    foreach (WorkItem queryResult in queryResults)
    {
        int TaskId = queryResult.Id;
        //int TaskPriority = queryResult.DisplayForm; // how to get the value of priority
        //string TaskTriage = queryResult.DisplayForm;//how to get the value of triage
        foreach (Field n in queryResult.Fields)
        {
            if (n.Name == "TaskPriority")
            {
                int TaskPriority = (int)n.Value; 
            }
            else if (n.Name == "TaskTriage")
            {
                string TaskTriage = (n.Value ?? string.Empty ).ToString(); 
            }
         }
            
         string TaskState = queryResult.State;
         DateTime TaskChangedDate = queryResult.ChangedDate;
         string TaskTitle = queryResult.Title;
    }
