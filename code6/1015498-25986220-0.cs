	public class ModelBaseMap:EntityTypeConfiguration<ModelBase>
	{
		public ModelBaseMap()
		{
			this.toTable("ModelBase");
		}
	}
	
	public class ModelMap:EntityTypeConfiguration<Model>
	{
		public ModelBaseMap()
		{
			this.toTable("Model");
		}
	}
