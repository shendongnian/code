        public class YourDbContext : DbContext
		{
			public IDbSet<IdentityRole> AspNetRoles { get; set; }
			public IDbSet<IdentityUserClaim> AspNetUserClaims { get; set; }
			public IDbSet<IdentityUserLogin> AspNetUserLogins { get; set; }
			public IDbSet<IdentityUserRole> AspNetUserRoles { get; set; }
			public IDbSet<FitAndStrongUser> AspNetUsers { get; set; }
			public YourDbContext() : base("DefaultConnection")
			{
			}
			protected override void OnModelCreating(DbModelBuilder modelBuilder)
			{
				modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
				modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
				modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
			}
		}
