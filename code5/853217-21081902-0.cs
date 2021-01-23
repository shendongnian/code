    var persons = 
        (from p in dbContext.Persons
         select new {
             person = p,
             lastMatchingNote = o.Notes.Where(x => x.Type == 5)
                                       .OrderByDescending(x => x.Date)
                                       .First()
         })
        .ToList();
