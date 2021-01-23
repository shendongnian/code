    from sr in db.Table<ServiceRecords>()
    where sr.CarID == id
    group sr by sr.ServiceType into g
    let lastRecord = g.OrderByDescending(sr => sr.ServiceDate).First()
    select new {
       lastRecord.MilesLastService,
       lastRecord.ServiceDate
    }
