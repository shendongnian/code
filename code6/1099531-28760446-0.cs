    var instrumentQuery = session.QueryOver<Musicians>()
         .Where(x=>x.Id == CONCRETEMUSICIANIDTHERE)
         .Fetch(x=>x.Instruments).Eager
         .Future();
    var instrumentProperties = = session.QueryOver<Musicians>()
         .Where(x=>x.Id == CONCRETEMUSICIANIDTHERE)
         .Fetch(x=>x.Instruments, ()=> instrumentAlias).Eager
         .Fetch(()=>instrumentAlias.Properties).Eager
         .Future();
    ...
    ...CONTINUE same future queries for each unique collection       
    ...
    ...
    var result = session.QueryOver<Musician>()
         .Where(x=>x.Id == CONCRETEMUSICIANIDTHERE)
         // all will be fetaures
         .Future()
         .SingleOrDefault<Musician>();
