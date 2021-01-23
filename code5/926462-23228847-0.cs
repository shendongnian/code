    if (programs.Count() > 0)
    {
       var progrmIds = programs.Select(e => e.Id).ToArray();  
       var areasResult = db.Areas.Where(r => programIds.Contains(r.ProgramId));
       areas.AddRange(areasResult);  // Storing areas in list
    }
    
