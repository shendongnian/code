    using (var db = new AnimalDbContext)
    {
        var cats = db.Animals.OfType<Cat>().ToArray();
        // Or when you want to get animals of multiple types
        var catsAndDogs = db.Animals.Where(a => a is Cat|| a is Dog).ToArray();
    }
