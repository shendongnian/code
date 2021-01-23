    var assignments = await (from g in db.AssignmentGroups.AsNoTracking().Where(x => x.AssignedToId == studentTask.Result.PersonId)
                                 join aa in db.ActivityAssignments.AsNoTracking() on g.Id equals aa.GroupId
                                 join a1 in db.Activities.AsNoTracking() on aa.ActivityId equals a1.Id into a2
                                 from a in a2.DefaultIfEmpty()
                                 select new ActivityListViewModel
                                 {
                                     Id = a == null ? null : a.Id,
                                     Points = g.PointValue ?? 0,
                                     Title = a == null ? null : a.Title,
                                     GroupId = g.Id,
                                     Complete = (aa.CompletedOn != null)
                                 });
