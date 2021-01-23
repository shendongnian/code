    class Program
	{
		static void Main(string[] args)
		{
		}
	}
	[TestFixture]
	public class program
	{
		[Test]
		public void some_test()
		{
			var fixture = new Fixture();
			fixture.Customize(new AutoConfiguredMoqCustomization());
			var simpleServices = fixture.CreateMany<ISimpleService>();
			foreach (var simpleService in simpleServices)
			{
				string randomString = simpleService.Buzz("hello");
				int randomInt = simpleService.Fizz(15);
			}
		}
	}
	public interface ISimpleService
	{
		int Fizz(int input);
		string Buzz(string input);
	}
