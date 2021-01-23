    [Theory, UnitTestConventions]
    public void Scenario2(
        ISpecimenBuilder builder,
        [Frozen]Mock<IRemotingFacade> stub,
        User[] users)
    {
        stub.Setup(x => x.GetUsers()).Returns(users);
        var sut = from x in new Methods<UserService>() select x.GetUsers();
            
        var assertion = new ReturnValueMustNotBeNullAssertion(builder);
        Assert.DoesNotThrow(() => assertion.Verify(sut));
    }
