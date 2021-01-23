    public class SomeClassMap : ClassMapping<SomeClass>
    {
    public SomeClassMap()
    {
        Table("SomeClassTable");
        Property(p => p.SomeClassID, map => 
        { 
            map.Column("SomeClassID");
            map.Generator(Generators.Identity);
        });
        Property(p => p.ClassTypeID, map => map.Column("ClassTypeID"));
        //Other properties here
        Join("SomeClassTypes", m => 
			{
				m.KeyColumn("ClassTypeId");
				m.Fetch.Join();
				m.Map(x => x.DescriptionType).Column("Description");
			})
    }
}
