    var results = db.CrossPuzzles.Where(m => m.ActivityID == id)
                                 .Where(m => m.IsAcross)
                                 .AsEnumerable()
                                 .ToList();
    
    //OR
    
    var results = db.CrossPuzzles.Where(m => m.ActivityID == id)
                                 .Where(m => m.IsAcross == "YES")
                                 .AsEnumerable()
                                 .ToList();
