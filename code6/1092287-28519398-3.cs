	public class HowAreYouWriter : IWriter
	{
		public readonly IWriter innerWriter;
		
		public HowAreYouWriter(IWriter innerWriter)
		{
			if (innerWriter == null)
				throw new ArgumentNullException("innerWriter");
			this.innerWriter = innerWriter;
		}
		
		public void WriteSomething()
		{
			this.innerWriter.WriteSomething();
			
			Console.WriteLine("How are you?");
		}
	}
    // Composition Root
    var nullWriter = new NullWriter();
    var goodbyeWriter = new GoodbyeWriter(nullWriter);
    var howAreYouWriter = new HowAreYouWriter(goodbyeWriter);
    var helloWriter = new HelloWriter(howAreYouWriter);
    var service = new SomeService(helloWriter);
    // End Composition Root
    // Execute
    service.Write();
    //Writes:
    
    //Hello.
    //How are you?
    //Goodbye.
