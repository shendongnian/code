	using System;
						
	public class Program
	{
		public static void Main()
		{
			var originalText = "{0} should be [this], and {2} should be [that], and there should be no [thus]";
			
			Console.WriteLine(originalText);
			
			var replacedText = string.Format(originalText, "this", "thus", "that");
			
			Console.WriteLine(replacedText);
		}
	}
