        public class ApplicationUserDbContext<TUser> : IdentityDbContext<TUser> 
      where TUser : ApplicationUser {
        public ApplicationUserDbContext(string nameOrConnectionString)
          : base(nameOrConnectionString) {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
    
            var user = modelBuilder.Entity<TUser>();
    
            user.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("UserNameIndex") { IsUnique = true, Order = 1}));
    
            user.Property(u => u.TenantId)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("UserNameIndex") { IsUnique = true, Order = 2 }));
        }
    }
The ValidateEntity method is a bit more tricky however, as we will have to reimplement the entire method in order to remove the hardcoded username checks:
    
        protected override DbEntityValidationResult ValidateEntity(
          DbEntityEntry entityEntry, IDictionary<object, object> items) {
            if (entityEntry != null && entityEntry.State == EntityState.Added) {
                var errors = new List<DbValidationError>();
                var user = entityEntry.Entity as TUser;
        
                if (user != null) {
                    if (this.Users.Any(u => string.Equals(u.UserName, user.UserName) 
                      && u.TenantId == user.TenantId)) {
                        errors.Add(new DbValidationError("User", 
                          string.Format("Username {0} is already taken for AppId {1}", 
                            user.UserName, user.TenantId)));
                    }
        
                    if (this.RequireUniqueEmail 
                      && this.Users.Any(u => string.Equals(u.Email, user.Email) 
                      && u.TenantId == user.TenantId)) {
                        errors.Add(new DbValidationError("User", 
                          string.Format("Email Address {0} is already taken for AppId {1}", 
                            user.UserName, user.TenantId)));
                    }
                }
                else {
                    var role = entityEntry.Entity as IdentityRole;
        
                    if (role != null && this.Roles.Any(r => string.Equals(r.Name, role.Name))) {
                        errors.Add(new DbValidationError("Role", 
                          string.Format("Role {0} already exists", role.Name)));
                    }
                }
                if (errors.Any()) {
                    return new DbEntityValidationResult(entityEntry, errors);
                }
            }
        
            return new DbEntityValidationResult(entityEntry, new List<DbValidationError>());
        }
**Client**
All that remains now is to initialise the classes. Don't forget you will need to supply the TenantId each time you new up the context. See the below example (note the use of 'example', these classes are all disposable...).
        var context = new ApplicationUserDbContext<ApplicationUser>("DefaultConnection");
    var userStore = new ApplicationUserStore<ApplicationUser>(context) { TenantId = 1 };
    var userManager = new UserManager<ApplicationUser, string>(userStore);
