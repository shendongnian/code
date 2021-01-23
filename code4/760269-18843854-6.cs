    public class CustomUserConfiguration : EntityTypeConfiguration<CustomUser>
    {
        public CustomUserConfiguration()
        {
            Map<CustomUser>(m => m.Requires("UserType").HasValue("CustomUser"));
        }
    }
     
