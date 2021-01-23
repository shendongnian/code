       public class PolizasDBContext: DbContext
    {
          public PolizasDBContext()
            : base("PolizasDBContext")
        { 
        }
          public DbSet<CatalogoDeCuentas> TablaCatalogoDeCuentas { get; set; }
          public DbSet<CodigoAgrupadorCuentas> TablaCodigoAgrupCuentas { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<CodigoAgrupadorCuentas>()
                .HasOptional(x => x.CatalogoDeCuentas)
                .WithRequired(x => x.CodigoAgrupadorCuentas);
            base.OnModelCreating(modelBuilder);
        }
    }
