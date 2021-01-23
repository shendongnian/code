    public sealed class Configuration : DbMigrationsConfiguration<Booking.EntityFramework.BookingDbContext> {
        public Configuration() {
           // ...
        }
        protected override void Seed(Booking.EntityFramework.BookingDbContext context) {
            // check configuration if seed must be skipped
            if (!bool.Parse(ConfigurationManager.AppSettings["Database.Seed"] ?? bool.TrueString)) return;
            // if here, seed your database
            // ...
        }
    }
