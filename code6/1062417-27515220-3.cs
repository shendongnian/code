	using System;
					
	public class Program
	{
		public static void Main()
		{
			string source = "[quote IdPost=8] Some quoting text [/quote]";
			
			Console.WriteLine(ExtractNum(source, "=", "]"));
			Console.WriteLine(ExtractNum2(source, "[quote IdPost="));
        }
		public static string ExtractNum(string source, string start, string end)
		{
			int index = source.IndexOf(start) + start.Length;
			return source.Substring(index, source.IndexOf(end) - index);
		}
		// just another solution for fun
		public static string ExtractNum2(string source, string junk)
		{
			source = source.Substring(junk.Length, source.Length - junk.Length); // erase start
			return source.Remove(source.IndexOf(']')); // erase end
		}
	}
