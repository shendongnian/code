    namespace CpuRegistry.DataContexts
    {
        public class CpuRegistryDb : IdentityDbContext<ApplicationUser>
        {
            public CpuRegistryDb()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }
    
            public static CpuRegistryDb Create()
            {
                return new CpuRegistryDb();
            }
    
            public DbSet<Region> Regions { get; set; }
            public DbSet<District> Districts { get; set; }
            public DbSet<Town> Towns { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
    
                modelBuilder.Entity<Town>().HasMany<District>(t => t.Districts).WithOptional(d => d.Town);
                modelBuilder.Entity<District>().HasMany<Town>(d => d.Towns).WithOptional(t => t.District);            
            }
        }
    }
   
    namespace CpuRegistry.Models
    {
        public enum TownType
        {
            Город, Посёлок, Село
        }
    
        public class Town
        {
            public int ID { get; set; }
    
            [Required]
            public string Name { get; set; }
    
            [Required]
            public int RegionID { get; set; }
    
            public int? DistrictID { get; set; }
    
            [Required]
            public TownType TownType { get; set; }
            public virtual ICollection<District> Districts { get; set; }
            public virtual Region Region { get; set; }
            public virtual District District { get; set; }
    
            public override string ToString()
            {
                return ID.ToString();
            }
        }
        public class District
        {
            public int ID { get; set; }
    
            [Required]
            public string Name { get; set; }
    
            [Required]
            public int RegionID { get; set; }
    
            public int? TownID { get; set; }
            public virtual ICollection<Town> Towns { get; set; }
            public virtual Region Region { get; set; }
            public virtual Town Town { get; set; }
    
            public override string ToString()
            {
                return ID.ToString();
            }
        }
    }
