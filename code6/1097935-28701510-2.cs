    void Tests(IEnumerable<tests> tests)
    {
        var result =
            from t in tests.Select(t => new {Teacher = t.teacher, Test = t.test, School = t.school}).Distinct()
            group t by t.Test
            into g
            where g.Select(t => t.Teacher).Distinct().Count() > 10
            select new
            {
                Test = g.Key,
                TeacherCount = g.Select(t => t.Teacher).Distinct().Count(),
                SchoolCount = g.Select(t => t.School).Distinct().Count()
            };
    }
