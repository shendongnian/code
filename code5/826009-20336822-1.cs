    // start with Tasks, filter by AccessLevel
    Tasks.Where( t => t.AccessLevel <= 5 )
        // get the TaskLinks for each Task
        .SelectMany( t => t.TaskLinks )
        // filter TaskLinks by IfInactive == false
        .Where( tl => !tl.IfInactive )
        // update to keep the hierarchy you want
        .GroupBy( tl => tl.Task )
        .Select( g => new
            {
                Task = g.Key,
                FilteredTaskLists = g.Select( tl => new 
                    {
                        TaskList = tl,
                        Entity = tl.Entity
                    } )
            } );
            
    
