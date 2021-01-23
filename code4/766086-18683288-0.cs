    using (var entities = new ModelEntities())
    {
        foreach (var s in services)
        {
           var service = s;
           entities.Services.AddObject(service);
        }
        entities.SaveChanges();
    }
