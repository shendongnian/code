	[DataContract(Name="EntityType",Namespace="")]
	public class EntityTypeData
	{
		[DataMember(IsRequired=true,Order=0)]
		public string Name { get; private set; }
		
		[DataMember(IsRequired=false,Order=1)]
		public ComponentList Components { get; private set; }
		
		public EntityTypeData(string name, IEnumerable<string> components = null)
		{
			Name = name;
			Components = new ComponentList();
			if(components != null)
			{
				Components.AddRange(components);
			}
		}
	}
	
	[CollectionDataContract(ItemName = "ComponentEntry", Namespace="")]
	public class ComponentList : List<string> {}
