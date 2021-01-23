    using (var db = OpenDbConnection())
    {
        db.DropAndCreateTable<Dog>();
        db.DropAndCreateTable<Bowl>();
        db.DropAndCreateTable<DogBowl>();
    
        var dog = new Dog { Breed = "Breed", Name = "Name" };
        var bowl = new Bowl { Color = "Color", Type = "Type" };
        db.Save(dog);
        db.Save(bowl);
        db.Insert(new DogBowl { DogId = dog.Id, BowlId = bowl.Id });
    
        var dogBowl = db.Select<DogBowlInfo>(
             db.From<Dog>()
              .Join<Dog, DogBowl>((d, b) => d.Id == b.DogId)
              .Join<DogBowl, Bowl>((d, b) => d.BowlId == b.Id)
              .Where<Dog>(d => d.Id == dog.Id));
    
        dogBowl.PrintDump();
    }
