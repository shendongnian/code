    var results = 
        (from p in dbContext.Persons
         select new {
             person = p,
             lastMatchingNote = p.Notes.Where(x => x.Type == 5)
                                       .OrderByDescending(x => x.Date)
                                       .First()
         })
        .ToList();
