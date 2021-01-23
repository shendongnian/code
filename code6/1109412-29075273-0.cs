     protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<MyEntity>().Property(x => x.BinaryProperty).HasMaxLength(LengthOfBinaryField).IsFixedLength();          
            }
