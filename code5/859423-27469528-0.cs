	using System;
	using System.Web;
	using System.Web.Security.AntiXss;
						
	public class Program
	{
		public static void Main()
		{
			string data = "Inside Microsoft® SharePoint® 2013";
			
			Console.WriteLine(" -- HttpUtility.HtmlEncode(data) --");
			Console.WriteLine(HttpUtility.HtmlEncode(data));
			
			Console.WriteLine(" -- AntiXssEncoder.HtmlEncode(data, false) --");
			Console.WriteLine(AntiXssEncoder.HtmlEncode(data, false));
			
			Console.WriteLine(" -- AntiXssEncoder.HtmlEncode(data, true) --");
			Console.WriteLine(AntiXssEncoder.HtmlEncode(data, true));
		}
	}
