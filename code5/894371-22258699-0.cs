    public AspNetRoleMap()
    {
        // Primary Key
        this.HasKey(t => t.Id);
        // Properties
        // Table & Column Mappings
        this.ToTable("AspNetRoles");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.Name).HasColumnName("Name");
        // Relationships
        this.HasMany(u => u.AspNetUsers)
            .WithMany(t => t.AspNetRoles)
            .Map(
                m =>
                {
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("UserId");
                    m.ToTable("AspNetUserRoles");
                }
            );
    }
