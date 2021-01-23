    var query = ....
                select new { e.Name, r.RoleType, e.Birthday, m.ID };
    var model = query.Distinct()
                     .Select(x => new EmployeeInfoViewModel {
                          Name = x.Name,
                          Birthday = x.Birthday,
                          ID = x.ID
                      }).ToList();
    return View(model);
