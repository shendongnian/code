	[TestClass]
	public class ServiceConsumerTestWithAutoMoq
	{
		[TestMethod]
		public void DoA()
		{
			//arrange
			var mocker = new AutoMoqer();
			var sut = mocker.Create<ServiceConsumer>();
			//act
			sut.DoA();
			//assert
			mocker.GetMock<IServiceA>().Verify(it => it.Do(), Times.Once());
			mocker.GetMock<IServiceB>().Verify(it => it.Do(), Times.Never());
		}
		[TestMethod]
		public void DoB()
		{
			//arrange
			var mocker = new AutoMoqer();
			var sut = mocker.Create<ServiceConsumer>();
			//act
			sut.DoB();
			//assert
			mocker.GetMock<IServiceA>().Verify(it => it.Do(), Times.Never());
			mocker.GetMock<IServiceB>().Verify(it => it.Do(), Times.Once());
		}
	}
	public interface IServiceConsumer
	{
		void DoA();
		void DoB();
	}
	public class ServiceConsumer : IServiceConsumer
	{
		public IServiceA serviceA { get; set; }
		public IServiceB serviceB { get; set; }
		public ServiceConsumer(
			IServiceA serviceA,
			IServiceB serviceB)
		{
			this.serviceA = serviceA;
			this.serviceB = serviceB;
		}
		public void DoA()
		{
			serviceA.Do();
		}
		public void DoB()
		{
			serviceB.Do();
		}
	}
	public interface IServiceA
	{
		void Do();
	}
	public interface IServiceB
	{
		void Do();
	}
