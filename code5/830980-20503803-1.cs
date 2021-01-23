	[Test]
	public void MyTest()
	{
		var target = new UnityContainer();
		target.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>();
		target.RegisterType<ICustomerRepository, CustomerRepository>();
		//act
		var unitOfWork1 = target.Resolve<IUnitOfWork>();
		var unitOfWork2 = target.Resolve<IUnitOfWork>();
		// assert
		// This Assert fails!
		unitOfWork1.Should().Be(unitOfWork2);
	} 
