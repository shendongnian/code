	class Class1Map : EntityTypeConfiguration<Class1>
	{
		public Class1Map()
		{
			this.HasKey(c => c.Id);
			this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			this.HasRequired(c1 => c1.Class2).WithRequiredPrincipal(c2 => c2.Class1);
		}
	}
