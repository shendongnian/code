	public abstract class EntityConfigurationBehavior
	{
		public abstract void Configure<TEntity>(EntityTypeConfiguration<TEntity> config);
	}
	public class DefaultConfigurationBehavior : EntityConfigurationBehavior
	{
		public override void Configure<TEntity>(EntityTypeConfiguration<TEntity> config)
		{
			config.HasKey(t => t.Id);
			config.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);        
			config.Ignore(t => t.IsActive);
		}
	}
