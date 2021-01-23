    var countsQuery =
        _db.Departments.All()
            .Select(p => new { key = 1, count = 0 })
            .Union(_db.Students.All().Select(p => new { key = 2, count = 0 }))
            .GroupBy(p => p.key)
            .Select(p => new { key = p.Key, count = p.Count() }).ToList();
    var counts = new CountsVm()
        {
            DepartmentCount =
                countsQuery.Where(p => p.key == 1)
                           .Select(p => p.count)
                           .FirstOrDefault(),
            StudentCount =
                countsQuery.Where(p => p.key == 2)
                           .Select(p => p.count)
                           .FirstOrDefault()
        };
