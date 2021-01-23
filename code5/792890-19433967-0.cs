	[TestClass]
	public class FormatterCoreTest
	{
		Mock<IConfigService> сonfigServiceMock;
		[TestInitialize]
		public void Init()
		{
			сonfigServiceMock = new Mock<IConfigService>();
		}
		[TestMethod]
		public void Format()
		{
            // arrange
			var input = /* input value */;
			var id = /* id value */;
			var сonfigServiceMock
				.Setup(services => services.YourMethodToMock())
				.Returnes(/* expected result or behaviour */);
            // act
			var target = new FormatterCore(сonfigServiceMock.Object);
			var result = target.Format</* AnyType */>(input, id);
            // assert
			/* Your asserts */
			result.Should().Be(/* expectred result */);
			Assert.AreEqual /* expectred result */, result);
		}
	}
