    var jobGroups = 
        context.BackgroundJobs
               .GroupBy(job => new { job.Description, job.RunDate })
               .Select(g => new { 
                                   g.Key, 
                                   g.Select((job,i) => new { 
                                                              RowCount = i + 1,
                                                              job
                                                           })
                                }
                      ).Tolist();
