     var pracResult = queryResult.GroupBy(t => new {t.RouteNbr, t.Day,t.NumberOfActionPlans,t.RouteNbrPlusDay})
                                 .OrderBy(l => l.Key.Day)
                                 .Select(grp =>new{ grp.Key.RouteNbr,
                                                     grp.Key.Day,
                                                     grp.Key.NumberOfActionPlans,
                                                     grp.Key.RouteNbrPlusDay}).ToList();
