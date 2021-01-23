	public abstract class XTimeEntityTypeConfiguration<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : XTimeEntity
	{
		// [...]
		
		protected EntityConfigurationBehavior ConfigurationBehavior { get; set; }
		
		// [...]
	}
