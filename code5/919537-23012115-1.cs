    // using System.Data.Entity;
    using (var db = new Context())
    {
        // Run these once per lifetime
        AutoMapper.Mapper.CreateMap<A, A>();
        AutoMapper.Mapper.CreateMap<C, C>();
        AutoMapper.Mapper.CreateMap<D, D>();
       
        var myObject = new A { Name = "joe", 
            Cs = new List<C> { new C { Name = "c1" } }, 
            Ds = new List<D> { new D { Name = "d1" } } 
        };
        db.As.Add(myObject);
        db.SaveChanges();
        
        var clonedObject = AutoMapper.Mapper.Map<A, A>(myObject);    
    
        db.As.Add(clonedObject);
        db.SaveChanges();
    
        db.As
            .Include(a => a.Cs)
            .Include(a => a.Ds)
            .ToList()
            .ForEach(a => Console.WriteLine("{0} - Cs: {1}, Ds: {2}",
                a.Name, a.Cs.Count(), a.Ds.Count())
                );
    }
