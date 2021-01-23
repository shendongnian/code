	[TestClass]
	public class ServiceConsumerTestWithInit
	{
		private Mock<IServiceA> serviceAMock;
		private Mock<IServiceB> serviceBMock;
		private IServiceConsumer sut;
		[TestInitialize]
		public void Initialize()
		{
			serviceAMock = new Mock<IServiceA>();
			serviceBMock = new Mock<IServiceB>();
			sut = new ServiceConsumer(
				serviceAMock.Object,
				serviceBMock.Object);
		}
		[TestMethod]
		public void DoA()
		{
			//act
			sut.DoA();
			//assert
			serviceAMock.Verify(it => it.Do(), Times.Once());
			serviceBMock.Verify(it => it.Do(), Times.Never());
		}
		[TestMethod]
		public void DoB()
		{
			//act
			sut.DoB();
			//assert
			serviceAMock.Verify(it => it.Do(), Times.Never());
			serviceBMock.Verify(it => it.Do(), Times.Once());
		}
	}
 
