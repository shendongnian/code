     var userMockReposioty = new Mock<IRepository<ApplicationUser>>();
                var userMockUserProvider = new Mock<IUserProvider>();
                userMockUserProvider.Setup(x => x.GetUserName())
                    .Returns("FakeUserName");
    
                userMockUserProvider.Setup(x => x.GetUserId())
                  .Returns("c52b2a96-8258-4cb0-b844-a6e443acb04b");
    
     mockUnitOfWork.Setup(x => x.Users).Returns(userMockReposioty.Object);
