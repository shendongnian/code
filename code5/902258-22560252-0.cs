    interface IFoo
    {
        int PorpertyA { get; }
        int PorpertyB { get; }
        ...
    }
    class FooImpl : IFoo
    {
        public int PorpertyA { get; set; }
        public int PorpertyB { get; set; }
        ...
    }
    IQueryable<IFoo> mergedQuery =
        fooBarQuery.Select(x => new FooImpl {
            PropertyA = x.PropertyA,
            PropertyB = x.PropertyB
            ...
        })
        .Union(fooBazQuery.Select(x => new FooImpl {
            PropertyA = x.PropertyA,
            PropertyB = x.PropertyB
            ...
        });
