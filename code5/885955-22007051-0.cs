    var ctx = new Context();
    var groupName = "something";
    var ruleInstances = from g in ctx.Groups
                        from gri in g.Rules.DefaultIfEmpty()
                        where g.Name == groupName
                        select gri.Id;
    var keys = from c in ctx.CurrentMembership
               let ri = c.RuleInstance
               from g in ri.Groups.DefaultIfEmpty()
               where c.IsMember && g.Name == groupName
               group c by c.EntityKey into g
               where g.Select(x => x.RuleInstanceId).Count() == ruleInstances.Distinct().Count()
               orderby g.Key
               select g.Key;
