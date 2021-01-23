	internal class Configuration<TEntity, TCreatedByKey> :
		Configuration<TEntity>
		where TEntity : class, ICreatableEntity, ICreatableEntity<TCreatedByKey>, IRemovableEntity, new()
		where TCreatedByKey : struct {
		protected override void ConfigureCreatableRelationships() {
			this.HasRequired(
				t =>
					t.CreatedBy).WithMany().HasForeignKey(
				k =>
					k.CreatedById);
		}
		protected override void ConfigureProperties() {
		}
		protected override void ConfigureRelationships() {
		}
	}
