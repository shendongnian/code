            var dataContext = new Mock<ICongressDbContext>();
            var members = new List<Member> { // create your test data here };
            // set up the mocked context to use your fake db set with test data
            dataContext.SetupProperty(c => c.Members, new FakeDbContext<Member>(members));
            
            var repository = new CongressRepository(dataContext.Object);
            
            // start writing your test methods here
