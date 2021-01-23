    public abstract class BaseMigration : Migration
    {
        // Update conventions for up migration
        public override void GetUpExpressions(IMigrationContext context)
        {
            this.UpdateConventions(context);
            base.GetUpExpressions(context);
        }
        // Update conventions for down migration
        public override void GetDownExpressions(IMigrationContext context)
        {
            this.UpdateConventions(context);
            base.GetDownExpressions(context);
        }
        // Change the conventions
        public void UpdateConventions(IMigrationContext context)
        {
            var conventions = ((MigrationConventions)context.Conventions);
            conventions.GetIndexName = index => DefaultMigrationConventions.GetIndexName(index).Replace("IX_", "uidx_");
        }
    }
