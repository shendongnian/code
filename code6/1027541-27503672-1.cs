    namespace Tests
    {
        [TestClass]
        public class CheckSeveralRelationsAtOnce
        {
            [TestMethod]
            public void HasAllAppsAndSkills()
            {
                int[] appIds = {1, 2, 3};
                int[] skillIds = {6, 7, 8};
                using (var ctx = new MyDbContext())
                {
                    ctx.Database.Log = Console.Write;
                    var usersWithAll = ctx.Users2.Where(u =>
                        appIds.All(aid => u.Apps.Any(a => a.AppId == aid))
                        && skillIds.All(sid => u.Skills.Any(s => s.SkillId == sid))
                        ).ToList();
                    Assert.IsNotNull(usersWithAll);
                }
            }
            [TestMethod]
            public void HasAnyAppsOrSkill()
            {
                int[] appIds = { 1, 2, 3 };
                int[] skillIds = { 6, 7, 8 };
                using (var ctx = new MyDbContext())
                {
                    ctx.Database.Log = Console.Write;
                    var usersWithAny = ctx.Users2.Where(u =>
                        appIds.Any(aid => u.Apps.Any(a => a.AppId == aid))
                        && skillIds.Any(sid => u.Skills.Any(s => s.SkillId == sid))
                        ).ToList();
                    Assert.IsNotNull(usersWithAny);
                }
            }
        }
    }
