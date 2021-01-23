    public class IdentityConfiguration : EntityTypeConfiguration<Identity>
    {
        public IdentityConfiguration()
        {
            HasMany(i => i.Accounts).WithRequired(i => i.Identity).HasForeignKey(a => a.IdentityId);            
        }
    }
