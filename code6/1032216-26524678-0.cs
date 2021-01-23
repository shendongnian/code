		public class TestService : ITestService
		{
			private readonly ITestData testData; // represents a bounded context
			public TestService(ITestData testData)
			{
				this.testData = testData;
			}
			public void DoSomething()
			{
				this.testData.Transactions.Add(...); //It gives you access to Transactions repository
			}
		}
