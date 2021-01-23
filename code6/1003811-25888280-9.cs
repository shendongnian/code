    public class VersionConfiguration : BaseObjectConfiguration<Version>
    {
        public VersionConfiguration()
            : base()
        {
            HasMany(mdv => mdv.ListOfSER)
                .WithRequired(x => x.Version)
                .HasForeignKey(ser => ser.VersionId)
                .WillCascadeOnDelete(false);
        }
    }
    public class SERConfiguration : BaseObjectConfiguration<SER>
    {
        public SERConfiguration()
            : base()
        {
            HasRequired(ar => ar.Version)
                .WithMany(x => x.ListOfSER)
                .HasForeignKey(ar => ar.VersionId)
                .WillCascadeOnDelete(false);
        }
    }
