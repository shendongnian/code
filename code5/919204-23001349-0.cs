    class HusbandMap : ClassMapping<Husband>
    {
      public HusbandMap()
      { 
        Id(x => x.HusbandId);
        Join("People", j =>
           {
              j.Key(x => x.Column("manId and relationType = 1"); //here is the sql injection hack :D
              j.ManyToOne(x => x.Wife);
           });
      }
    }
