     var users = new List<User>
            {
                new User
                {
                    UserId=1,
                    UserName="testUser@example.com"
                },
                new User
                {
                    UserId=5,
                    UserName="otherUser@example.com"
                }
            };
            var mockContext = new Mock<MyContext>();
            mockContext.Setup(x => x.Users)
                .Returns(new Mock<DbSet<User>>().SetupData(users).Object);
