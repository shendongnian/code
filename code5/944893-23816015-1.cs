    var activities = db.UserActivity
                        .GroupBy(a => a.ActivityId, 
                                 (k, g) => new { 
                                    ActivityId = k, 
                                    TotalPoints = g.Select(a => a.Points).sum() 
                                });
                                 
     var activitiesWithMostPoints = activities
                                    .Where(a => a.TotalPoints == activities.Max(a => a.TotalPoints));
     
