    using System.Data.Entity.ModelConfiguration;
    public class ApplicationUserConfig : EntityTypeConfiguration<ApplicationUser>
    {
        public UserConfig()
        {
            ToTable("Users");
            Property(u => u.LocationName).IsRequired();
        }
    }
