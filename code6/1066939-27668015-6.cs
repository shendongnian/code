    public class CarsDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasRequired(x => x.CarDetails).WithRequiredPrincipal(x => x.Car)
            ;
            modelBuilder.Entity<CarDetails>();
            base.OnModelCreating(modelBuilder);
        }
    }
