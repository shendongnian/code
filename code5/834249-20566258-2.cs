    var coesData = context.CoesData.Select(x => new 
    { 
        x.Id,
        x.UploadCOESDetails.AuditZoneId,
        x.UploadCOESDetails.AuditMonth,
        x.InspectorId,
        x.AuditType,
        /* etc. */
        DefectCount = x.COESDetailsCOESDefects.Count(),
        /* or this if it works... */
        HasDefects = x.COESDetailsCOESDefects.Any()
    })
