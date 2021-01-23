    public class CarsDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>();
            modelBuilder.Entity<CarDetails>()
                .HasRequired(x => x.Car).WithRequiredDependent(x => x.CarDetails)
            ;
            base.OnModelCreating(modelBuilder);
        }
    }
