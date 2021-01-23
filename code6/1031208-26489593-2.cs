	public class MyClass
	{
		public virtual int MyMethod()
		{
			return 5;
		}
	}
	[Test]
	public void ShouldGiveMeZero()
	{
		var mockMyClass = new Mock<MyClass>();
		// returns default(int)
		Assert.AreEqual(0, mockMyClass.Object.MyMethod());
	}
	[Test]
	public void ShouldGiveMeFive()
	{
		var mockMyClass = new Mock<MyClass>();
		mockMyClass.CallBase = true;
		// calls concrete implementation
		Assert.AreEqual(5, mockMyClass.Object.MyMethod());            
	}
	[Test]
	public void ShouldGiveMeSix()
	{
		var mockMyClass = new Mock<MyClass>();
		mockMyClass.Setup(x => x.MyMethod()).Returns(6);
		// calls Setup
		Assert.AreEqual(6, mockMyClass.Object.MyMethod());
	}
