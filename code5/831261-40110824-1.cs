    public class HMContext : DbContext
        {
            public HMContext()
            : base("name=HMContext")
            {
                Database.SetInitializer<HMContext>(null);
            }
            
            /// ... ///
    
            public virtual DbSet<Medicine> Medicines { get; set; }
            public virtual DbSet<MedicineGeneric> MedicineGenerics { get; set; }
            public virtual DbSet<MedicineStrength> MedicineStrengths { get; set; }
            public virtual DbSet<MedicineType> MedicineTypes { get; set; }
            public virtual DbSet<MedicineDosage> MedicineDosages { get; set; }
            public virtual DbSet<MedicineCategory> MedicineCategories { get; set; }
            public virtual DbSet<MetricPrefix> MetricPrefixes { get; set; }
            public virtual DbSet<Unit> Units { get; set; }
    
            ///...///
        } 
