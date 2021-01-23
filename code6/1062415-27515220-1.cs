	using System;
					
	public class Program
	{
		public static void Main()
		{
			string source = "[quote IdPost=8] Some quoting text [/quote]";
			
			Console.WriteLine(ExtractNum(source, "=", "]"));
		    // Console.WriteLine(Extract(source, "] ", " [/quote"));		
        }
		public static string ExtractNum(string source, string start, string end)
		{
			int index = source.IndexOf(start) + start.Length;
			return source.Substring(index, source.IndexOf(end) - index);
		}
		//public static string Extract(string source, string start, string end)
		//{
		//	int index = source.IndexOf(start) + start.Length;
		//	return source.Substring(index, source.LastIndexOf(end) - index);
		//}
	}
