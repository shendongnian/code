    public class ReadOnlyEntities : Entities
    {
        public bool EnforceReadonlyBehavior { get; set; }
        public ReadOnlyEntities(string connectionString)
            : base(connectionString)
        {
            EnforceReadonlyBehavior = true;
        }
        public override int SaveChanges(System.Data.Objects.SaveOptions options)
        {
            if (EnforceReadonlyBehavior)
            {
                if (
                    ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added).Any()
                    ||
                    ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Modified).Any()
                    ||
                    ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Deleted).Any()
                    )
                {
                    throw new InvalidOperationException("nope");
                }
            }
            return base.SaveChanges(options);
        }
    }
