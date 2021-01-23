        [TestMethod]
        public void DeleteApplication()
        {
            var data =
                new[]
                {
                    new Application { Id = 1, Name = "Application1" }, new Application { Id = 2, Name = "Application2" },
                    new Application { Id = 3, Name = "Application3" }, new Application { Id = 4, Name = "Application4" }
                }
                    .AsQueryable();
            var mockSet = new Mock<DbSet<Application>>();
            mockSet.As<IQueryable<Application>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Application>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Application>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Application>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(m => m.Applications).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Verifiable();
            // Act 
            var commandHandler = new DeleteApplicationCommandHandler(mockContext.Object);
            var commandArg = new ApplicationCommandArg { Id = 1 };
            commandHandler.Execute(new DeleteApplicationCommand(commandArg));
            // Verify
            mockSet.Verify(m => m.Remove(It.IsAny<Application>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            mockContext.VerifyGet(m => m.Applications, Times.Exactly(3));
        }
