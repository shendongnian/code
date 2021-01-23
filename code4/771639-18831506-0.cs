    Projects = group.Select(pd => new 
                { // This level deals with the first level of computation
                    Count = group.Count(),
                    CostToComplete = group.Sum(pdd => pdd.totals.costToComplete),
                    TimeWorkable = new UserBillingRate(WS, group.Key.manager, new Period(start, end)).TimeWorkable
                  // This level takes the computed results, and add derived computations
                }).Select(pd => new {
                    pd.Count,
                    pd.CostToComplete,
                    pd.TimeWorkable,
                  // Now that pd is an anonymous class created by the level above,
                  // both pd.CostToComplete and pd.TimeWorkable are defined.
                    StatusOfCharge = pd.CostToComplete / pd.TimeWorkable
                })
