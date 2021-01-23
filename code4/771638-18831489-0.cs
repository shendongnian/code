    var projectsByManagersAndMonths = projectDates
        .Where(pd => pd.project.isEnabled)
        .GroupBy(pd => new { pd.project.manager, pd.project.dtEnd.Value.Month })
        .Select(group => new
            {
                Manager = group.Key.manager.displayName,
                Month = group.Key.Month,
                Projects = group.Select(pd => new 
                    { 
                        Count = group.Count(),
                        CostToComplete = group.Sum(pdd => pdd.totals.costToComplete),
                        TimeWorkable = new UserBillingRate(WS, group.Key.manager, new Period(start, end)).TimeWorkable,
                    }).Select(pd => new 
                    { 
                        Count = pd.Count,
                        CostToComplete = pd.CostToComplete,
                        TimeWorkable = pd.TimeWorkable,
                        StatusOfCharge = pd.CostToComplete / pd.TimeWorkable //POSSIBLE
                    })
            })
        .ToList();
