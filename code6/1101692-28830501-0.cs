    .Select(z => new BondCompletionViewModel
    {
       EmployeeId = z.EmployeeId.Value,
       EmployeeName = z.Name,
       StartDate = z.JoiningDate,
       EndDate =  EntityFunctions.AddMonths(z.JoiningDate, x.Commitments.Value)
    }).ToList();
