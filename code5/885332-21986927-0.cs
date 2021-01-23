    var d2 = (from m in db.Table<ServiceRecords>()
              where m.CarID == carid && m.ServiceType == "TransmissionService"
              select new {ServiceDate = m.ServiceDate, MilesLastService = m.MilesLastService})
             .OrderBy(x => x.ServiceDate)
             .Last();
    var milesLastService = d2.MilesLastService;
    var serviceDate = d2.ServiceDate;
