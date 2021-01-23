    public class ApplicationUserEntityTypeConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserEntityTypeConfiguration()
        {
            Ignore(p => p.AccessFailedCount);
            //And so on..
        }
    }
