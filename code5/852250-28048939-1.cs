        var entryPoint = dbContext.tbl_EntryPoint
        .Join(
            dbContext.tbl_Entry,
            entryPoint => entryPoint.EID,
            entry => entry.EID,
            (entryPoint, entry) => new { entryPoint, entry }
        )
        .Join(
            dbContext.tbl_Title,
            combinedEntry => combinedEntry.entry.TID,
            title => title.TID,
            (combinedEntry, title) => new 
            {
                UID = combinedEntry.entry.OwnerUID,
                TID = combinedEntry.entry.TID,
                EID = combinedEntry.entryPoint.EID,
                Title = title.Title
            }
        )
        .Where(fullEntry => fullEntry.UID == user.UID)
        .Take(10);
  
