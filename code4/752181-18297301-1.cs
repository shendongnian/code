        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(AspnetIdentitySample.Models.MyDbContext context)
        {
            context.Users.AddOrUpdate(
                p => p.UserName,
                new MyUser { UserName = "John Doe" }
            );
        }
