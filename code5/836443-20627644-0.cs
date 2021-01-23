    var items = services.Select(s=>new ServiceDetails{
     ServiceName = s.ServiceName,
     Status = s.Status,
     Description = s.Description,
     Location = s.Location
    }).ToList();
