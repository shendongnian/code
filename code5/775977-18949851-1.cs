    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    		{
    			if (modelBuilder == null) throw new ArgumentNullException("modelBuilder");
    
    			modelBuilder.Entity<WebSiteEntity>()
    						.HasKey(site => site.Identity)
    						.ToTable("WebSite");
    
    			#region Security
    
    			modelBuilder.Entity<MemberEntity>()
    						.ToTable("Member")
    						.HasMany(u => u.Roles)
    						.WithRequired()
    						.HasForeignKey(ur => ur.UserId);
    			modelBuilder.Entity<MemberEntity>()
    						.HasMany(u => u.Claims)
    						.WithRequired()
    						.HasForeignKey(uc => uc.UserId);
    			modelBuilder.Entity<MemberEntity>()
    						.HasMany(u => u.Logins)
    						.WithRequired()
    						.HasForeignKey(ul => ul.UserId);
    			modelBuilder.Entity<MemberEntity>()
    						.Property(u => u.Moniker)
    						.HasMaxLength(50)
    						.HasColumnAnnotation("Index",
    											new IndexAnnotation(new IndexAttribute("UserNameIndex")
    																{
    																	IsUnique = true,
    																	IsClustered = false,
    																	Order = 2
    																}))
    						.HasColumnAnnotation("Index",
    											new IndexAnnotation(new IndexAttribute("MonikerIndex")
    																{
    																	IsUnique = true,
    																	IsClustered = false,
    																	Order = 1
    																}));
    			modelBuilder.Entity<MemberEntity>()
    						.Property(u => u.LastName)
    						.HasMaxLength(256)
    						.HasColumnAnnotation("Index",
    											new IndexAnnotation(new IndexAttribute("UserNameIndex")
    																{
    																	IsUnique = true,
    																	IsClustered = false,
    																	Order = 3
    																}))
    						.HasColumnAnnotation("Index",
    											new IndexAnnotation(new IndexAttribute("MonikerIndex")
    																{
    																	IsUnique = true,
    																	IsClustered = false,
    																	Order = 2
    																}));
    			;
    			modelBuilder.Entity<MemberEntity>()
    						.Property(u => u.FirstName)
    						.HasMaxLength(256)
    						.HasColumnAnnotation("Index",
    											new IndexAnnotation(new IndexAttribute("UserNameIndex")
    																{
    																	IsUnique = true,
    																	IsClustered = false,
    																	Order = 4
    																}))
    						.HasColumnAnnotation("Index",
    											new IndexAnnotation(new IndexAttribute("MonikerIndex")
    																{
    																	IsUnique = true,
    																	IsClustered = false,
    																	Order = 3
    																}));
    			;
    			modelBuilder.Entity<MemberEntity>()
    						.Property(u => u.Middle)
    						.HasMaxLength(256);
    			modelBuilder.Entity<MemberEntity>()
    						.Property(u => u.UserName)
    						.IsRequired()
    						.HasMaxLength(256)
    						.HasColumnAnnotation("Index",
    											new IndexAnnotation(new IndexAttribute("UserNameIndex")
    																{
    																	IsUnique = true,
    																	IsClustered = false,
    																	Order = 1
    																}))
    						.HasColumnAnnotation("Index",
    											new IndexAnnotation(new IndexAttribute("MonikerIndex")
    																{
    																	IsUnique = true,
    																	IsClustered = false,
    																	Order = 4
    																}));
    			modelBuilder.Entity<MemberEntity>()
    						.Property(u => u.Email)
    						.HasMaxLength(256);
    			modelBuilder.Entity<MemberRole>()
    						.HasKey(userRole => new
    											{
    												userRole.UserId,
    												userRole.RoleId
    											})
    						.ToTable("MemberRole");
    			modelBuilder.Entity<MemberLogin>()
    						.HasKey(login => new
    										{
    											login.UserId,
    											login.ProviderKey,
    											login.LoginProvider
    										})
    						.ToTable("MemberLogin");
    			modelBuilder.Entity<MemberClaim>()
    						.ToTable("MemberClaim");
    			modelBuilder.Entity<RoleEntity>()
    						.ToTable("Role");
    			modelBuilder.Entity<RoleEntity>()
    						.Property(r => r.Name)
    						.IsRequired()
    						.HasMaxLength(256)
    						.HasColumnAnnotation("Index",
    											new IndexAnnotation(new IndexAttribute("RoleNameIndex")
    																{
    																	IsUnique = true
    																}));
    			modelBuilder.Entity<RoleEntity>()
    						.HasMany(r => r.Users)
    						.WithRequired()
    						.HasForeignKey(ur => ur.RoleId);
    
    			#endregion
