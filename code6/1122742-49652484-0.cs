        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Appoiment>().HasOne(a => a.ApplicationUser)
                    .WithMany(au => au.Appointments)
                    .HasForeignKey(a => a.ApplicationUserId)
                    .IsRequired(false);
        }
       
