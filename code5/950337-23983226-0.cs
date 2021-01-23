    var t = repo.GetAll().AsQueryable()
    .GroupBy(c => c.Category.Family.ID)
    .Select(g => new {
        FamilyID = g.Key,
        DevicesByCategory = g.GroupBy(c => c.Category.ID)
            .Select(g2 => new {
                CategoryID = g2.Key,
                Devices = g2.Select(c => new UserConfigs {
                    ....
            })
       })
    });
