	[Fact]
	public void ArgumentsAsAnonimusType()
	{
		// Arrange.
		var container = new WindsorContainer();
		container.Register(Component.For<Event>().ImplementedBy<Event>());
		container.Register(Component.For<IRegisteredType>().ImplementedBy<RegisteredType>());
		var passNow = new PassNow();
		var local = DateTimeOffset.Now;
		var world = DateTimeOffset.UtcNow;
		local.Should().NotBe(world);
		// Act.
		var result = container.Resolve<Event>(new { passNow = passNow, local = local, world = world });
		// Assert.
		result.Should().BeOfType<Event>();
		result.RegisteredType.Should().Be(container.Resolve<IRegisteredType>());
		result.PassNow.Should().Be(passNow);
		result.Local.Should().Be(local);
		result.World.Should().Be(world);
	}
