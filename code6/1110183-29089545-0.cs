    class A
    {
       int Id { get; set; }
       int Version { get; set; }
       string Name { get; set; }
    }
    
    class AMap : ClassMap<A>
    {
       public AMap()
       {
          Id (x => x.Id).GeneratedBy.Native();
          Version (x => x.Version);
          Map(x => x.Name);
       }
    }
