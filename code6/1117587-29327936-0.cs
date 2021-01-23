    (...)
    .OrderByDescending(o => 
       o.tbl_Application.tbl_ApplicationChanges
          .Where(ac => ac.ApplicationID == o.ApplicationID)
          .OrderByDescending(ac => ac.ChangeDate)
          .First()
          .Select(ac => ac.ChangeDate)
    )
    (...)
