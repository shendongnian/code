        [TestMethod]
        public void UpdateApplication()
        {
            const string newAplpicationName = "NewApplication1";
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
            // Act 
            var commandHandler = new UpdateApplicationCommandHandler(mockContext.Object);
            var commandArg = new ApplicationCommandArg { Id = 1, Name = newAplpicationName };
            commandHandler.Execute(new UpdateApplicationCommand(commandArg));
            Assert.AreEqual(newAplpicationName, data.First(m => m.Id == 1).Name);
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
