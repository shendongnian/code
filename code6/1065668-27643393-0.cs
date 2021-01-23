    var deparments = context.Departments.OfType<Finance>().Include(p => p.Manager)
                     .AsEnumerable()
                     .OfType<Department>()
                     .Union(
                     context.Departments.OfType<Sports>().Include(p => p.Coach)
                     ).ToList();
