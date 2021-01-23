      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
            modelBuilder.Entity<TableA>().HasOptional(a => a.TableC).WithOptionalPrincipal(c => c.TableA);
            base.OnModelCreating(modelBuilder);
      }
