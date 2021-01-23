    var list = session
            .QueryOver<Employee>()
            .WhereRestrictionOn(c => c.Age).IsBetween(18).And(60)
            .Select(c => c.Name)
            .OrderBy(c => c.Name).Asc
            .List<string>();
