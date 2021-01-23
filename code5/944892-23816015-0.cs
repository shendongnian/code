    var activityWithMostPoints = db.UserActivity
                                .GroupBy(a => a.ActivityId, 
                                         (k, g) => new { 
                                            ActivityId = k, 
                                            TotalPoints = g.Select(a => a.Points).Sum() 
                                        })
                                .OrderByDescending(a => a.TotalPoints)
                                .First();
