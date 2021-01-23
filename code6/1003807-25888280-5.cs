    public class VersionConfiguration : BaseObjectConfiguration<Version>
    {
        public VersionConfiguration()
            : base()
        {
            HasMany(mdv => mdv.ListOfSER)
                .WithRequired()
                .HasForeignKey(ser => ser.VersionId) // -> belongs to base class
                .WillCascadeOnDelete(false);
        }
    }
