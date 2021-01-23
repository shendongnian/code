    var result = (from a in context.ERP_Applications
                   join u1 in context.COM_City_Workers on a.CreatedBy equals u1.Employee_ID.Trim()
                   join u2 in context.COM_City_Workers on a.ModifiedBy equals u2.Employee_ID.Trim() into us
                   from u2 in us.DefaultIfEmpty()
                   where a.ApplicationId == applicationId
                   select new Entity.Application()
                   {
                       Id = a.ApplicationId,
                       Name = a.ApplicationName,
                       Description = a.ApplicationDesc,
                       DateTimeCreated = a.DateTimeCreated,
                       CreatedBy = new Entity.Employee
                       {
                           EmployeeID = a.CreatedBy,
                           FirstName = u1.First_Name,
                           LastName = u1.Last_Name
                       },
                       DateTimeModified = a.DateTimeModified ?? null,
                       ModifiedBy = new Entity.Employee
                       {
                           EmployeeID = a.ModifiedBy ?? string.Empty,
                           FirstName = u2.First_Name ?? string.Empty,
                           LastName = u2.Last_Name ?? string.Empty
                       }
                   }).Single();
