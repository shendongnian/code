	using System;
						
	public class Program
	{
		public static void Main()
		{
			var originalText = "{0} is a sentence that contains {0} more than once.";
			
			Console.WriteLine(originalText);
			
			var replacedText = string.Format(originalText, "~that~");
			
			Console.WriteLine(replacedText);
		}
	}
