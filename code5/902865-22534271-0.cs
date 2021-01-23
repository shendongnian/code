    Container c = getContainer();
    Foo f = new Foo();
    f.Name = "blah";
    c.AddToFoos(f); 
    Thing t = c.Things.Where(v => v.id==7).FirstOrDefault();
    c.AddLink(f, "Thing", t); // Thing is the Navigation property name from f to t.
    c.SaveChanges(SaveChangesOptions.BatchWithSingleChangeset);
