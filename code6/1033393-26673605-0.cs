    var activityFilterCustomerIds = db.Activities
        .Where(a => 
            a.CreatedDateTime >= search.BeginDateCreated &&
            a.CreatedDateTime <= search.EndDateCreated)
        .Select(a => a.CustomerId)
        .Distinct()
        .ToList();
    var groupFilterCustomerIds = db.CustomerGroup
        .Where(g => g.GroupId = search.GroupId)
        .Select(g => g.CustomerId)
        .Distinct()
        .ToList();
    var customers = db.Customers
        .AsNoTracking()
        .Where(c => 
            activityFilterCustomerIds.Contains(c.Id) &&
            groupFilterCustomerIds.Contains(c.Id))
        .ToList();
    var customerIds = customers.Select(x => x.Id).ToList();
    var newSales =
        (from s in db.Sales
        where customerIds.Contains(s.CustomerId)
        && s.Employee.IsActive
        group s by s.CustomerId into grouped
        select new
        {
            CustomerId = grouped.Key,
            Sale = grouped
                .OrderByDescending(x => x.DateCreated)
                .Select(new PolicyViewModel
                {
                    // properties
                })
                .FirstOrDefault()
        }).ToList();
        
    var existingSales = 
        (from s in db.Sales
        where customerIds.Contains(s.CustomerId)
        && (s.CancellationDate == null || s.CancellationDate <= myDate)
        && s.SaleDate < myDate
        group s by s.CustomerId into grouped
        select new
        {
            CustomerId = grouped.Key,
            Sale = grouped
                .OrderByDescending(x => x.DateCreated)
                .Select(new SalesViewModel
                {
                    // properties
                })
                .FirstOrDefault()
        }).ToList();
    var currentStatuses = 
        (from a in db.Activities.AsNoTracking()
        where customerIds.Contains(a.CustomerId)
        && a.ActivityType.IsReportable
        group a by a.CustomerId into grouped
        select new
        {
            CustomerId = grouped.Key,
            Status = grouped
                .OrderByDescending(x => x.DueDateTime)
                .Select(x => x.Disposition.Name)
                .FirstOrDefault()
        }).ToList();
    var customerGroups =
        (from cg in db.CustomerGroups
        where cg.GroupId == search.GroupId
        group cg by cg.CustomerId into grouped
        select new
        {
            CustomerId = grouped.Key,
            Group = grouped
                .Select(x =>
                    new GroupViewModel
                    {
                        // ...
                    })
                .FirstOrDefault()
        }).ToList();
        return customers
            .Select(c =>
                new CustomCustomerReport
                {
                    // ... simple props
                    // ...
                    // ...
                    NewSale = newSales
                        .Where(s => s.CustomerId == c.Id)
                        .Select(x => x.Sale)
                        .FirstOrDefault(),
                    ExistingSale = existingSales
                        .Where(s => s.CustomerId == c.Id)
                        .Select(x => x.Sale)
                        .FirstOrDefault(),
                    CurrentStatus = currentStatuses
                        .Where(s => s.CustomerId == c.Id)
                        .Select(x => x.Status)
                        .FirstOrDefault(),
                    CustomerGroup = customerGroups
                        .Where(s => s.CustomerId == c.Id)
                        .Select(x => x.Group)
                        .FirstOrDefault(),
                })
            .ToList();
