    var manager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(
                    context));
            var user0 = new ApplicationUser()
            {
                UserName = "User0",
                FirstName = "FirstName0",
                LastName = "LastName0",
                Email = "Email0@Example.com",
            };
            manager.Create(user0, "Password0");
            var user1 = new ApplicationUser()
            {
                UserName = "User1",
                FirstName = "FirstName1",
                LastName = "LastName1",
                Email = "Email1@Example.com",
            };
            manager.Create(user1, "Password1");
            
            var user2 = new ApplicationUser()
            {
                UserName = "User2",
                FirstName = "FirstName2",
                LastName = "LastName2",
                Email = "Email2@Example.com",
            };
            var eventObj = new Event()
            {
                Id = Guid.NewGuid(),
                Host = user2,
                Header = "Header0",
                Description = "Description0",
                Date = DateTime.Now
            };
            context.Events.AddOrUpdate(eventObj);
            manager.Create(user2, "Password2");
