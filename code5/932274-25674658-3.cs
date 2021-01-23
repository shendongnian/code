    public class IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserClaim, TGroup, TGroupRole> : DbContext
        where TUser : IdentityUser<TKey, TUserLogin, TUserClaim, TGroup, TGroupRole>
        where TRole : IdentityRole<TKey, TGroupRole>
        where TUserLogin : IdentityUserLogin<TKey>
        where TUserClaim : IdentityUserClaim<TKey>
        where TGroup : IdentityGroup<TKey, TGroupRole>
        where TGroupRole : IdentityGroupRole<TKey>
    {
        private IdentityConfiguration _config;
        public virtual IDbSet<TUser> Users { get; set; }
        public virtual IDbSet<TRole> Roles { get; set; }
        public virtual IDbSet<TGroup> Groups { get; set; }
        public bool RequireUniqueEmail { get; set; }
        public IdentityDbContext()
            : this("DefaultConnection", new IdentityConfiguration())
        {
        }
        public IdentityDbContext(string nameOrConnectionString)
            : this(nameOrConnectionString, new IdentityConfiguration())
        {
        }
        public IdentityDbContext(string nameOrConnectionString, IdentityConfiguration config)
            : base(nameOrConnectionString)
        {
            _config = config;
        }
        public IdentityDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }
            var user = modelBuilder.Entity<TUser>().ToTable(_config.UserTableName, _config.Schema);
            user.HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
            user.HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
            user.HasOptional(u => u.Group).WithMany().Map(m => m.MapKey("GroupId"));
            user.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserNameIndex") { IsUnique = true }));
    
            // CONSIDER: u.Email is Required if set on options?
            user.Property(u => u.Email).HasMaxLength(256);
    
            modelBuilder.Entity<TGroupRole>().HasKey((TGroupRole r) => new
            {
                r.GroupId,
                r.RoleId
            }).ToTable(_config.GroupRoleTableName, _config.Schema);
    
            modelBuilder.Entity<TUserLogin>().HasKey((TUserLogin l) => new
            {
                l.LoginProvider,
                l.ProviderKey,
                l.UserId
            }).ToTable(_config.LoginTableName, _config.Schema);
    
            modelBuilder.Entity<TUserClaim>().ToTable(_config.ClaimTableName, _config.Schema);
    
            var role = modelBuilder.Entity<TRole>()
                .ToTable(_config.RoleTableName, _config.Schema);
            role.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("RoleNameIndex") { IsUnique = true }));
            role.HasMany(r => r.Groups).WithRequired().HasForeignKey(ur => ur.RoleId).WillCascadeOnDelete();
    
            var group = modelBuilder.Entity<TGroup>()
                .ToTable(_config.GroupTableName, _config.Schema);
            group.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("GroupNameIndex") { IsUnique = true }));
            group.HasMany(r => r.Roles).WithRequired().HasForeignKey(ur => ur.GroupId).WillCascadeOnDelete();
            //group.HasMany(g => g.Users).WithOptional().Map(m => m.MapKey("GroupId"));
        }
        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            if (entityEntry != null && entityEntry.State == EntityState.Added)
            {
                List<DbValidationError> list = new List<DbValidationError>();
                TUser user = entityEntry.Entity as TUser;
                if (user != null)
                {
                    if (this.Users.Any((TUser u) => string.Equals(u.UserName, user.UserName)))
                    {
                        list.Add(new DbValidationError("User", string.Format(CultureInfo.CurrentCulture, IdentityResources.DuplicateUserName, new object[]
    					{
    						user.UserName
    					})));
                    }
                    if (this.RequireUniqueEmail && this.Users.Any((TUser u) => string.Equals(u.Email, user.Email)))
                    {
                        list.Add(new DbValidationError("User", string.Format(CultureInfo.CurrentCulture, IdentityResources.DuplicateEmail, new object[]
    					{
    						user.Email
    					})));
                    }
                }
                else
                {
                    TRole role = entityEntry.Entity as TRole;
                    if (role != null && this.Roles.Any((TRole r) => string.Equals(r.Name, role.Name)))
                    {
                        list.Add(new DbValidationError("Role", string.Format(CultureInfo.CurrentCulture, IdentityResources.RoleAlreadyExists, new object[]
    					{
    						role.Name
    					})));
                    }
                }
                if (list.Any<DbValidationError>())
                {
                    return new DbEntityValidationResult(entityEntry, list);
                }
            }
            return base.ValidateEntity(entityEntry, items);
        }
    }
