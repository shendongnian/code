    var eig = new List<PostEig>()
    {
        new PostEig(){EigTwo = "Foo1", EigA =  "Foo"},
        new PostEig(){EigTwo = "Foo2", EigA =  "Foo"},
        new PostEig(){EigTwo = "Bar1", EigA =  "Bar"},
        new PostEig(){EigTwo = "Bar2", EigA =  "Bar"}
    };
    var data = new List<PostOne>()
    {
        new PostOne(){Two = "Foo1", ThrD = new DateTime(1900,1,1)},
        new PostOne(){Two = "Foo2", ThrD = new DateTime(2000,1,1)},
        new PostOne(){Two = "Foo3", ThrD = new DateTime(1900,1,1)},
        new PostOne(){Two = "Bar1", ThrD = new DateTime(1900,1,1)},
        new PostOne(){Two = "Bar2", ThrD = new DateTime(1900,1,1)}
    };
    var authName = "Foo";
    var currentDate = new DateTime(1900,1,1);
    //Not sure if this is the most optimal LINQ Query, but it seems to work.
    var queryReturn = data.Join(eig.Where(x => x.EigA == authName), x => x.Two, y => y.EigTwo, (x, y) => x)
        .Where(z => z.ThrD == currentDate)
        .ToList();
    queryReturn.ForEach(x => Console.WriteLine(x.Two + " - " + x.ThrD)); //Foo1 - 1/1/1900
