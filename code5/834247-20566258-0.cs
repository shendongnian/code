    var coesData = context.CoesData.Select(x => new 
    { 
        x.Id,
        x.UploadCOESDetails.AuditZoneId,
        x.UploadCOESDetails.AuditMonth,
        x.InspectorId,
        x.AuditType,
        /* etc. */
        Count = x.COESDetailsCOESDefects.Count()
    })
