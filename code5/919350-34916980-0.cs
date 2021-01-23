    public class LookupSchoolsConfiguration : EntityTypeConfiguration<LookupSchools>
        {
            public LookupSchoolsConfiguration()
            {
                Property(l => l.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            }
        }
