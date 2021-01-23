	public class NullWriter : IWriter
    {
        public void WriteSomething()
		{
			// Do nothing - this is a "null object pattern".
		}
    }
	
	public class HelloWriter : IWriter
	{
		public readonly IWriter innerWriter;
		
		public HelloWriter(IWriter innerWriter)
		{
			if (innerWriter == null)
				throw new ArgumentNullException("innerWriter");
			this.innerWriter = innerWriter;
		}
		
		public void WriteSomething()
		{
			this.innerWriter.WriteSomething();
			
			Console.WriteLine("Hello.");
		}
	}
	public class GoodbyeWriter : IWriter
	{
		public readonly IWriter innerWriter;
		
		public GoodbyeWriter(IWriter innerWriter)
		{
			if (innerWriter == null)
				throw new ArgumentNullException("innerWriter");
			this.innerWriter = innerWriter;
		}
		
		public void WriteSomething()
		{
			this.innerWriter.WriteSomething();
			
			Console.WriteLine("Goodbye.");
		}
	}
	public class SomeService : ISomeService
	{
		private readonly IWriter writer;
		public SomeService(IWriter writer)
		{
			if (writer == null)
				throw new ArgumentNullException("writer");
		}
		public void Write()
		{
			this.writer.WriteSomething();
		}
	}
