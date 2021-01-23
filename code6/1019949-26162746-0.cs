    var assignments = from g in db.AssignmentGroups.AsNoTracking().Where(x => x.AssignedToId == studentTask.Result.PersonId)
                              join aa in db.ActivityAssignments.AsNoTracking() on g.Id equals aa.GroupId
                              join a in db.Activities.AsNoTracking() on aa.ActivityId equals a.Id
                              from aq in db.ActivityQuestions.Where(q => q.ActivityId == a.Id).DefaultIfEmpty()
                              group aq by new { ActivityId = a.Id, Title = a.Title, GroupId = g.Id, Points = g.PointValue ?? 0, Completed = (aa.CompletedOn != null) } into s
                              select new ActivityListViewModel
                              {
                                  Id = s.Key.ActivityId,
                                  Points = s.Key.Points + s.Sum(y => y.PointValue ?? 0), //g.PointValue ?? 0, 
                                  Title = s.Key.Title,
                                  GroupId = s.Key.GroupId,
                                  Complete = s.Key.Completed
                              };
