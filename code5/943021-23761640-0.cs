    modelBuilder.Entity<Lens>() 
    .Map(m => 
    { 
        m.Properties(t => new { t.Id, t.LightHead, t.LightHead1 }); 
        m.ToTable("Lens"); 
    }) 
    .Map(m => 
    { 
        m.Properties(t => new { t.Id, t.Lens, t.Lens1 }); 
        m.ToTable("LightHead"); 
    });
