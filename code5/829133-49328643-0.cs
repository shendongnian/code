    var products =
       context
       .Products
       .Select(p => new {
          p.ID,
          p.Name
       }).AsEnumerable() // come out of EF
       .Select(anon => new Product { // manually load into product objects
          ID = anon.ID,
          Name = anon.Name
       }).ToList();
