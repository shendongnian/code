    var employee = db.Employee.AsQueryable():
    var predicate = PredicateBuilder.False<Employee>();
    if (model.IsSicked == true)
        predicate = predicate.Or(p => p.IsSick == model.IsSick);
    if (model.IsRetired == true)
        predicate = predicate.Or(p => p.IsRetired == model.IsRetired);
    if (model.IsHoliday == true)
        predicate = predicate.Or(p => p.IsHoliday == model.IsHoliday);
    var result = employee.AsExpandable().Where(c => predicate.Invoke(c)).ToList()
