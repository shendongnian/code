    modelBuilder.Entity<DomainUser>()
                .Map<AdministrationUser>(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("AdministrationUsers");
                })
                .Map<SupplierUser>(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("SupplierUsers");
                })
                .Map<Customer>(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("Customers");
                });
    modelBuilder.Entity<DomainUser>()
                .HasRequired(domainUser => domainUser.IdentityUser)
                .WithRequiredPrincipal(groomUser => groomUser.DomainUser);
