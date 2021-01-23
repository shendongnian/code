        var db = new SomethingThatIsADbContext();
        var query = (from f in db.Foos
                     join b in db.Bars on f.IDFoo equals b.IDFoo
                     join fb in db.Fubars on b.IDBar equals fb.IDBar
                     select new MyViewModel { 
                                f.IDFoo,
                                f.NameFoo, 
                                f.CityFoo, 
                                b.NameBar, 
                                fb.NameFubar }).ToList();
