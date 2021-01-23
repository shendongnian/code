    public class VersionConfiguration : BaseObjectConfiguration<Version>
    {
        public VersionConfiguration()
            : base()
        {
            HasMany(mdv => mdv.ListOfSER)
                .WithRequired() // -> this should be WithRequired(x => x.Version)
                .HasForeignKey(ser => ser.VersionId)
                .WillCascadeOnDelete(false);
        }
    }
    public class AbstractRConfiguration : BaseObjectConfiguration<AbstractR>
    {
        public AbstractRConfiguration()
            : base()
        {
            HasRequired(ar => ar.Version)
                .WithMany() // -> this should be WithMany(x => x.ListOfSER)
                .HasForeignKey(ar => ar.VersionId)
                .WillCascadeOnDelete(false);
        }
    }
