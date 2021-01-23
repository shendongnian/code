	[Test]
	public void MyTest()
	{
		var target = new UnityContainer();
		target.RegisterType<IRepository<Customer>, CustomerRepository>();
		//act
		var repository = target.Resolve<IRepository<Customer>>();
		// assert
		repository.Should().NotBeNull();
		repository.Should().BeOfType<CustomerRepository>();
	}
