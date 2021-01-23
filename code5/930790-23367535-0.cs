    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            HasKey(t => t.Id);
            // Table & Column Mappings
            Map<PrivateCustomer>(m =>
            {
                m.ToTable("AccessUser");
                m.Properties(p => p.PrivateName);
                m.Requires("ClientType").HasValue(1);
            });
            Map<CorporateCustomer>(m =>
            {
                m.ToTable("AccessUser");
                m.Properties(p => p.CompanyName);
                m.Requires("ClientType").HasValue(2);
                m.Property(p=>p.CompanyName).HasColumnName("AccessUserCompany");
            });
            Map(m =>
            {
                m.ToTable("CustomerSet");
                m.Properties(p => new
                {
                    p.Id,
                    p.Leasing,
                });
            });
            Map(m =>
            {
                m.ToTable("SiriusCustomer");
                m.Properties(p => new
                {
                    p.Id,
                    p.Address
                });
                m.Property(p => p.Id).HasColumnName("AccessUserId");
                m.Property(p => p.Address).HasColumnName("SiriusAddres");
            });
            Map(m =>
            {
                m.ToTable("AccessUser");
                m.Properties(p => new
                {
                    p.Id,
                    p.Name,
                });
                m.Property(p => p.Id).HasColumnName("AccessUserId");
                m.Property(p => p.Name).HasColumnName("AccessUserName");
            });
        }
    }
