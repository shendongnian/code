		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// usualy i put this line to the end of this method but it should be before
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<ApplicationUserRole>().HasKey(hk => new { hk.UserId, hk.RoleId, hk.ServiceId});
		}
