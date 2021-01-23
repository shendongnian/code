    var requestedSkillIDs = new[] { 4, 5, 6 };
    var skillCount = requestedSkillIDs.Length;
    var requestedAppIDs = new[] { 1, 2, 3 };
    var appCount = requestedAppIDs.Length;
    
    using (var context = new TestContext()) {
        context.Database.CreateIfNotExists();
    
        var appQuery = context.UserApp.Where(p => requestedAppIDs.Contains(p.AppId))
                            .GroupBy(p => p.UserId)
                            .Where(p => p.Count() == appCount);
    
        var skillQuery = context.UserSkill.Where(p => requestedSkillIDs.Contains(p.SkillId))
                            .GroupBy(p => p.UserId)
                            .Where(p => p.Count() == skillCount);
    
        var result = from a in appQuery
                        join s in skillQuery on a.Key equals s.Key
                        join u in context.Users on s.Key equals u.Id
                        select u;
    
    
        var users = result.ToList();
    }
