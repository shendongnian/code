	[SetUp]
	public  void SetUp()
    {
        // this will make AutoFixture create mocks automatically for all dependencies
		_fixture = new Fixture()
             .Customize(new AutoMoqCustomization()); 
        // whenever AutoFixture needs IUnitOfWork it will use the same  mock object
        // (something like a singleton scope in IOC container)
		_fixture.Freeze<Mock<IUnitOfWork>>(); 
        // suppose YourSystemUnderTest takes IUnitOfWork as dependency,
        // it'll get the one frozen the line above
		_sut = _fixture.Create<YourSystemUnderTest>(); 
	}
	[Test]
	public void SomeTest()
	{
		var id = _fixture.Create<object>(); // some random id
		var fooObject = _fixture.Create<Foo>(); // the object repository should return for id
        // setuping THE SAME mock object that wa passed to _sut in SetUp.
        // _fixture.Freeze<Mock part is ESSENTIAL
        // _fixture.Freeze<Mock<IUnitOfWork>>() returns the mock object, so whatever comes
        // next is Mock specific and you'll have to use NSubstitute syntax instead
		_fixture.Freeze<Mock<IUnitOfWork>>()
                .Setup(uow => uow.FooRepository.GetById(id))
                .Returns(fooObject); 
        // if this method will ask the unit of work for FooRepository.GetById(id)
        // it will get fooObject.
		var whatever = _sut.SomeMethod(id); 
		// do assertions
	}
