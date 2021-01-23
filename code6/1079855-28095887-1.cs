    public ILookup<string,string> GetResourcesAndActivitiesByUser(string userName)
    {
            using (var _db = new AppDbContext())
            {
                return (from u in _db.Users
                        where u.UserName == userName
                        from a in _db.Activities
                        join ra in _db.RoleResourceActivities on a.Id equals ra.ActivityId
                        join r in _db.Resources on ra.ResourceId equals r.Id
                        join ro in _db.Roles on ra.RoleId equals ro.Id
                        where u.Roles.Contains(ro)
                        select new { Resource = r.Name, Activity = a.Name })
                        .ToLookup(e => e.Resource, e => e.Activity);
            }
    }
