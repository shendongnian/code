            List<FooBar> lstFooBar = new List<FooBar>() { new FooBar() { r = 1 } };
            List<FooBaz> lstFooBaz = new List<FooBaz>() { new FooBaz() { z = 2 } };
            IQueryable<FooBar> fooBarQuery = lstFooBar.AsQueryable<FooBar>();
            IQueryable<FooBaz> fooBazQuery = lstFooBaz.AsQueryable<FooBaz>();
            IQueryable<IFoo> mergedQuery = fooBazQuery.Cast<IFoo>  
                                           ().Concat(fooBarQuery.Cast<IFoo>());
