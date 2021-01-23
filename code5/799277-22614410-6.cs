    [Theory, UnitTestConventions]
    public void Scenario1(
        ISpecimenBuilder builder,
        [Frozen]Mock<IRemotingFacade> stub)
    {
        stub.Setup(x => x.GetUsers()).Returns((User[])null);
        var sut = from x in new Methods<UserService>() select x.GetUsers();
            
        var assertion = new ReturnValueMustNotBeNullAssertion(builder);
        Assert.Throws<ReturnValueMustNotBeNullException>(() =>
            assertion.Verify(sut));
    }
