    public class TestEfContext : ApplicationDbContext {
		public DbSet<Town> Towns { get; set; }
		public DbSet<District> Districts { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Town>()
				.HasMany<District>(x => x.Districts)
				.WithOptional(x => x.Town);
			modelBuilder.Entity<District>()
				.HasMany<Town>(x => x.Towns)
				.WithOptional(x => x.District);
		}
	}
	public class Town {
		[Key]
		public int Id { get; set; }
		public District District { get; set; }
		public virtual ICollection<District> Districts { get; set; }
		public override string ToString() {
			return Id.ToString();
		}
	}
	public class District {
		[Key]
		public int Id { get; set; }
		public Town Town { get; set; }
		public virtual ICollection<Town> Towns { get; set; }
		public override string ToString() {
			return Id.ToString();
		}
	}
