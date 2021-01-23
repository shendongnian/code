	public class Foo
	{
		public Foo()
		{			
		}
		
		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public void CreateDebugMessage()
		{
			AddMessageType(MessageType.Debug, "Debug",
				"/Company.App.Class;component/Images/image.png", Brushes.Green, false);
		}
	}
    var foo = new Foo();
    foo.CreateDebugMessage();
