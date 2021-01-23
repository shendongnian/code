    var groupedAR = db.ApplicantsRecords.GroupBy(x => x.SessionId)
        .Select(y => new
        {
            SessionId = y.Key,
            ApplicationsRecords = y.FirstOrDefault(),
        }).OrderByDescending(x => x.ApplicationsRecords.LoginDate);
    foreach (var i in groupedAR)
    {
        ar.Add(i.ApplicationsRecords);
    }
    return View(ar.ToPagedList(page, 10));
