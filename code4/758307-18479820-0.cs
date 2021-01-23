    public class Com
    {
        public virtual Guid ID { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Lob> Lobs { get; set; }
    }
    public class Lob
    {
        public virtual Guid ID { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Com> Coms { get; set; }
    }
    class LobMap : ClassMap<Lob>
    {
        public LobMap()
        {
            Id(x => x.ID).GeneratedBy.GuidComb();
            Map(x => x.Name);
            HasManyToMany(x => x.Coms)
            .Table("LOB_COM")
            .ParentKeyColumn("LOB_ID")
            .ChildKeyColumn("COM_ID")
            .Cascade.SaveUpdate()
            .LazyLoad();
        }
    }
    class ComMap : ClassMap<Com>
    {
        public ComMap()
        {
            Id(x => x.ID).GeneratedBy.GuidComb();
            Map(x => x.Name);
            HasManyToMany(x => x.Lobs)
            .Table("LOB_COM")
            .ParentKeyColumn("COM_ID")
            .ChildKeyColumn("LOB_ID")
            .Inverse()
            .Cascade.All()
            .LazyLoad();
        }
    }
