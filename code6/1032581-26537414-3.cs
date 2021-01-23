	public class Program
	{
		public static void Main()
		{
			var originalText = "~this~ is a sentence that contains ~this~ more than once.";
			
			Console.WriteLine(originalText);
			
			var replacedText = originalText.Replace("~this~", "~that~");
			
			Console.WriteLine(replacedText);
		}
	}
