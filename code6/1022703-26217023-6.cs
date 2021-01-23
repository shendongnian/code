    List<Devision> devisions = Table.AsEnumerable()
        .GroupBy(row => row.Field<int>("DevisionId"))
        .Select(devGrp => new Devision(
            devGrp.Key,
            devGrp.GroupBy(row => row.Field<int>("EmployeeId"))
                   .Select(g => new Employees(
                       g.Key,
                       g.Select(r => new Info(r.Field<DateTime>("date"), r.Field<float>("Hour")))
                        .ToList()))
                  .ToList()))
        .ToList();
