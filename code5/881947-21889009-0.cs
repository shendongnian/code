		public class BasePage
		{        
			public int Id { get; set; }
			public virtual MapCoordinate Map { get; set; }
			...
		}
		public class Region : BasePage
		{        			
			...
		}
		public class Place: BasePage
		{        
			...
		}
		public class MapCoordinate
		{
			[Key]
			public int BasePageId { get; set; }
			...
		}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<BasePage>()
						.HasRequired(e => e.MapCoordinate)
						.WithRequiredPrincipal();
        
			modelBuilder.Entity<BasePage>().ToTable(BasePages);
			modelBuilder.Entity<MapCoordinate>().ToTable(MapCoordinates);
		}
