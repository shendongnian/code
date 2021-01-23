    [Theory, UnitTestConventions]
    public void Scenario3(
        ISpecimenBuilder builder,
        [Frozen]Mock<IRemotingFacade> stub,
        User[] users)
    {
        stub.Setup(x => x.GetUsers()).Returns(users);
        var sut = from x in new Methods<UserService>() 
                  select x.GetUsers(default(int));
            
        var assertion = new ReturnValueMustNotBeNullAssertion(builder);
        Assert.Throws<ReturnValueMustNotBeNullException>(
            () => assertion.Verify(sut));
    }
