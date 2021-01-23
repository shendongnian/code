	public class BarMap : ClassMap<Bar>
	{
		this.Id(x => x.Id);
		this.Map(x => x.Name);
		this.References(x => x.FooFactory);
	}
	
	public class FooFactoryBaseMap : ClassMap<FooFactoryBase>
	{
		this.Id(x => x.Id);
		this.HasMany(x => x.Bars).Inverse();
		this.DiscriminateSubClassesOnColumn("Id");
	}
	
	public class Foo1FactoryMap : SubClassMap<Foo1Factory>
	{
		this.DiscriminatorValue(Foo1Factory.Guid);
	}
	
