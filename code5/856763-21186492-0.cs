    var result = (
    from device in DevicesRepository.GetAll()
    group device by new { Date = EntityFunctions.TruncateTime(device.Added)} into g
    select new
        {
            Date = g.Key.Date,
            Count = g.Count()
        }
    ).OrderBy(nda => nda.Date);
