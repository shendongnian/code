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
			Property(p => p.DescriptionType, ?); //This line
			Join("SomeClassTypes", m => 
				{
					m.Key(k => k.Column("ClassTypeId"));
					m.Fetch(FetchKind.Join);
					m.Property(x => x.DescriptionType).Column("Description");
				});
		}
	}
