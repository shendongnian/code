     public AMap() 
     {
        ....
        ....
        HasMany(a=> a.B).KeyColumn("aID").Inverse().Cascade.All();
     }
     public BMap()
     {
       CompositeId()
             .KeyProperty(b=> b.AID)
             .KeyProperty(b=> b.Name)
             .KeyProperty(b=> b.Year);
       References(b=> b.A).Column("aID");
       Map(b=> b.Name);
       Map(b=> b.Year);
     }
