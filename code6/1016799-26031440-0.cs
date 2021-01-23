	public delegate void TestAction(string locator);
	public class Action
	{
		public string ExpectedAction { get; set; }
		public TestAction Test { get; set; }
	}
