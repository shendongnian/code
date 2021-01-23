	internal abstract class Configuration<TEntity> :
		EntityTypeConfiguration<TEntity>
		where TEntity : class, ICreatableEntity, IRemovableEntity, new() {
		protected virtual void Configure() {
			this.ConfigureCreatableProperties();
			this.ConfigureRemovableProperties();
			this.ConfigureProperties();
			this.ConfigureCreatableRelationships();
			this.ConfigureRemovableRelationships();
			this.ConfigureRelationships();
		}
		#region Property Configurations
		protected virtual void ConfigureCreatableProperties() {
			this.Property(
				p =>
					p.CreatedDateTime).HasColumnType("datetime2");
		}
		protected virtual void ConfigureRemovableProperties() {
			this.Property(
				p =>
					p.RemovedDateTime).HasColumnType("datetime2");
		}
		protected abstract void ConfigureProperties();
		#endregion
		#region Relationship Configurations
		protected abstract void ConfigureCreatableRelationships();
		protected virtual void ConfigureRemovableRelationships() {
			this.HasOptional(
				t =>
					t.RemovedBy).WithMany().HasForeignKey(
				k =>
					k.RemovedById);
		}
		protected abstract void ConfigureRelationships();
		#endregion
	}
