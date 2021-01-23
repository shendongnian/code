    // no wrapping in Task, it is async
    var activityList = await dataService.GetActivitiesAsync();
    
    // Select a good enough tuple
    var results = (from activity in activityList
                   select new { 
                    Activity = activity, 
                    AthleteTask = dataService.GetAthleteAsync(activity.AthleteID)
                   }).ToList(); // begin enumeration
    
    // Wait for them to finish, ie relinquish control of the thread
    await Task.WhenAll(results.Select(t => t.AthleteTask));
    
    // Set the athletes
    foreach(var pair in results)
    {
      pair.Activity.Athlete = pair.AthleteTask.Result;
    }
