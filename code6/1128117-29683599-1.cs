    var taskAllCompleted = Requests.Where(r => r.RequestStatusID == 2 ||
                                               r.RequestStatusID == 6)
                                   .SelectMany(r=>r.Tasks)
                                   .Any(t=> t.TaskStatusID != 2 && 
                                            t.TaskStatusID != 5);
    if ( taskAllCompleted )
    {
        RequestsNeedsAction.Add( request );
    }
