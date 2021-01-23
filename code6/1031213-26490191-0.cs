    .Select(c => new 
    {
       ...
       tmpThosePresent = c.VisitAttendances
        .SingleOrDefault(v => v.CaseNoteID == c.CaseNoteID)
       ...
    }
    .ToList()
    .Select(c => new
    {
        ...
        ThosePresent = c.tmpThosePresent != null
           ? c.tmpThosePresent.CasePersonID.ToString()
           : "No One"
        ...
    });
