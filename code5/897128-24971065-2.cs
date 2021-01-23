	[SetUp]
	public  void SetUp(){
		_fixture = new Fixture().Customize(new AutoMoqCustomization()); // this will make AutoFixture create mocks automatically for all dependencies
		_fixture.Freeze<Mock<IUnitOfWork>>(); // whenever AutoFixture needs IUnitOfWork it will use the same  mock object (something like a singleton scope in IOC container)
		_sut = _fixture.Create<YourSystemUnderTest>(); // suppose YourSystemUnderTest takes IUnitOfWork as dependency, it'll get the one frozen the line above
	}
	[Test]
	public void SomeTest()
	{
		var id = _fixture.Create<object>(); // some random id
		var fooObject = _fixture.Create<Foo>(); // the object repository should return for id
		_fixture.Freeze<Mock<IUnitOfWork>>().Setup(uow => uow.FooRepository.GetById(id)).Returns(fooObject); // setuping THE SAME mock object that wa passed to _sut in SetUp. _fixture.Freeze<Mock part is ESSENTIAL
		var whatever = _sut.SomeMethod(id); // if this method will ask the unit of work for FooRepository.GetById(id) it will get fooObject.
		// do assertions
	}
