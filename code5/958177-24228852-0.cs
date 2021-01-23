    mb.Entity<SomeObject>()
                .Property(so => so.Type)
                .IsUnicode(false)
                .HasColumnName("Type")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
