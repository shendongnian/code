        var model = new SomethingThatIsADbContext();
        var query = (from u in model.Universitates
                     join f in model.Facultates on u.IDUniv equals f.IDUniv
                     join s in model.Specializares on f.IDFac equals s.IDFac
                     select new MyViewModel() { 
                                u.NumeUniv, 
                                u.OrasUniv, 
                                u.IDUniv, 
                                f.NumeFac, 
                                s.NumeSpec }).ToList();
