	public delegate void TestAction(string locator);
	public class ActionCase
	{
		public string ExpectedAction { get; set; }
		public TestAction Test { get; set; }
	}
