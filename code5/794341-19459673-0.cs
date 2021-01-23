            var dataContext = new Mock<ICongressDbContext>();
            var members = new List<Member> { // create your test data here };
            dataContext.SetupProperty(c => c.Members, new FakeDbContext<Member>(members);
            
            var repository = new CongressRepository(dataContext.Object);
            
            // start writing your test methods here
