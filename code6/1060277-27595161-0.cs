    public class OrganizationXREFConfiguration : EntityTypeConfiguration<OrganizationXREF>
    {
        public OrganizationXREFConfiguration()
        {
            ToTable("OrganizationXREF");
            HasRequired(ar => ar.Parent).WithMany(a => a.Parents);
            HasRequired(ar => ar.Child).WithMany(a => a.Children);
        }
    }
