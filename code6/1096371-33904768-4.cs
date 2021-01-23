           private UserController BuildCoontrollerWithDatabase()
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder.UseInMemoryDatabase();
           
            ApplicationDbContext applicationDbContext = new ApplicationDbContext( dbContextOptionsBuilder.Options);
            var userStore = new UserStore<ApplicationUser>(applicationDbContext);
            UserManager<ApplicationUser>  userManager = TestUserManager<ApplicationUser>(userStore);
            return new UserController(userManager);
            
             
        }
