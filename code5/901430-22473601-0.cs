    protected override void Seed(MusicStoreEntities context)
    {        
        context.Categries.Add(new Categories { Name = "Guitars" });
        context.Categries.Add(new Categories { Name = "Keyboards" });
        context.Categries.Add(new Categories { Name = "Drums" });
        context.Categries.Add(new Categories { Name="Amplifiers"});
        
        base.Seed(context);
    }
