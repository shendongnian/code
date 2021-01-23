    var item = (from obj in _db.SampleEntity.Include(s => s.NavProp1)
       select new
       {
            ItemProp1 = obj,
            NavProp1 = obj.NavProp1,
            ItemProp2 = obj.NavProp2.Any(n => n.Active)
       }).SingleOrDefault();
    
    Assert.IsNotNull(item.NavProp1)
