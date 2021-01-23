        List<FooBar> list = new List<FooBar> 
        {
            new FooBar{ r=1},
            new FooBar{ r=2},
            new FooBar{ r=3},
        };
        List<FooBaz> list2 = new List<FooBaz> 
        {
            new FooBaz{ z=4},
            new FooBaz{ z=5},
            new FooBaz{ z=6},
        };
        IQueryable<IFoo> fooBarQuery = list.AsQueryable();
        IQueryable<IFoo> fooBazQuery = list2.AsQueryable();
        IQueryable<IFoo> mergedQuery = fooBarQuery.Concat(fooBazQuery);
        foreach (var obj in mergedQuery)
            Console.WriteLine(obj);
    }
    interface IFoo
    { }
    class FooBar:IFoo {
        public int r { get; set; }
    }
    class FooBaz : IFoo
    {
        public int z { get; set; }
    }
