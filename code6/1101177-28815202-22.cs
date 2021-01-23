    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            Property(x => x.CSL).IsRequired();
            //relational properties
            HasRequired(x => x.UserType).WithMany(x => x.Users).HasForeignKey(x => x.UserType_ID);
            HasRequired(x => x.TimelineVolumetry).WithRequiredPrincipal(x => x.User);           
        }
    }
    public class TimelineVolumetryMap : EntityTypeConfiguration<TimelineVolumetry>
    {
        public TimelineVolumetryMap()
        {
            Property(x => x.AllowedWeeks).IsRequired();
        }
    }
