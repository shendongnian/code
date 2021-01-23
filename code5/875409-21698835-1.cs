    context.AppealPersons
        .GroupBy(ap => ap.Appeal.Id, ap => ap,
            (key, g) => new { 
                AppealId = key, 
                Appeal = g.FirstOrDefault().Appeal, 
                Persons = String.Join(",", g.Select(x => x.Person)
                    .AsEnumerable()
                    .Select(p => String.Format("{0} {1} {2}", p.Surname, p.Name, p.MiddleName).Trim()))
            })
        .ToList();
