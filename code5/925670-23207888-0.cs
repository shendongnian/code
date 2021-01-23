	internal class Configuration<TEntity> :
		EntityTypeConfiguration<TEntity>
		where TEntity : class, ICreatableEntity, new() {
		protected virtual void Configure() {
			this.Configure(ConfigurationParameters.Default);
		}
		protected virtual void Configure(
			ConfigurationParameters parameters) {
			this.ConfigureCreatableRelationships(parameters.CreatedByWillCascadeOnDelete);
		}
		#region Relationship Configurations
		protected virtual void ConfigureCreatableRelationships(
			bool willCascadeOnDelete) {
			this.HasRequired(
				t =>
					t.CreatedBy).WithMany().Map(
				m =>
					m.MapKey("CreatedById")).WillCascadeOnDelete(willCascadeOnDelete);
		}
		#endregion
	}
