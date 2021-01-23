    void YourAction(...) {
        FooEntities db = new FooEntities();
        var stuff = db.StuffAtStore.Select(s => 
            new StuffViewModel
            {
                Name = s.Name,
                Price = s.Price,
 
                // This will use Outer Apply, which may not be available
                // for EF providers other than Microsoft's MSSQL provider.
                PersonIfAny = db.Wishlist.Where(w => w.Name == s.Name)
                                .Select(w => w.Person).FirstOrDefault();
            }
        foreach(var s : stuff) 
        {
            s.PersonIfAny = s.PersonIfAny ?? "";
        }
        return View(stuff);
      
    }
