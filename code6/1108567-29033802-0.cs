    public class DataContext : DbContext {
        //other properties
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             modelBuilder.Entity<CompanyInfo>()
                .HasRequired(m => m.CompanyAddress)
                .WithOptional()
                .Map(m => { m.MapKey("CompanyAddressId"); });
        }
    }
