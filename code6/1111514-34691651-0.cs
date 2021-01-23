	[Test]
	public void RecursiveMockTest()
	{
		// Arrange
		bool isEventHandled = false;
		var parentMock = new Mock<IParent>();
		parentMock.DefaultValue = DefaultValue.Mock;
		var parent = parentMock.Object;
		// get the actual mock which was automatically setup for you
		var childMock = Mock.Get(parent.Child);
		parent.Child.SomethingHappened +=
			(sender, args) =>
			{
				isEventHandled = true;
			};
		// Act on the mock which was setup for you
		childMock.Raise(x => x.SomethingHappened += null, EventArgs.Empty);
		// Assert
		Assert.IsTrue(isEventHandled);
	}
