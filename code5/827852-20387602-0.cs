        List<Developer> developers =
        employees.Where(x => x.Department == "Dev")
                 .Select(x => new Developer
                 {
                     Name = x.Name,
                     Department = x.Department,
                     JobTitle = x.Function,
                     Division = String.Concat(x.Function, "/", x.Department)
                 }).ToList();
        return developers;
