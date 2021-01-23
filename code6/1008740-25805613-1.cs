    _repository = new Mock<MyRepository<IdentityUser>>(dbContext.Object);
    _repository.Setup(x => x.SetEntityStateModified(It.IsAny<IdentityUser>()))
            .Callback(() => { });
    _repository.Setup(x => x.SetPropertyIsModified(It.IsAny<IdentityUser>()))
            .Callback(() => { });
