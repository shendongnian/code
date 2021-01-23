	class Program
	{
		private const string BrokenXml = 
			"<root>\n" +
			"\t<childone>\n" +
			"\t\t<attributeone name=\"aa\">aa</attributeone>\n" +
			"\t\t<attributetwo adds=\"ba\">ab&\"'<</attributetwo>\n" +
			"\t\t<attributeone name=\"aa\">&</attributeone>\n" +
			"\t<empty />\n" +
			"\t</childone>\n" +
			"</root>";
		// Matches an opening tag with 0 or more attributes, and captures everything within "<...>" as Groups[1].
		// Unescaped regex looks like: <(\w+(?:\s+\w+="[^"]*")?)>
		private static Regex OpenTagRegex = new Regex("<(\\w+(?:\\s+\\w+=\"[^\"]*\")?)>");
		// Matches a close tag and captures everything within "<...>" as Groups[1].
		private static Regex CloseTagRegex = new Regex("<(/\\w+)>");
		// Matches an empty tag and captures everything within "<...>" as Groups[1].
		private static Regex EmptyTagRegex = new Regex("<(\\w+\\s*/)>");
		public static void Main(string[] args)
		{
			//Replace the angular brackets (<>) of all valid xml elements with curly brackets ({})
			string step1 = OpenTagRegex.Replace(BrokenXml, ReplaceMatch);
			string step2 = CloseTagRegex.Replace(step1, ReplaceMatch);
			string step3 = EmptyTagRegex.Replace(step2, ReplaceMatch);
			//Fix the remaining special characters with their xml entity counterparts:
			string step4 = step3.Replace("&", "&amp;");
			string step5 = step4.Replace("<", "&lt;");
			string step6 = step5.Replace(">", "&gt;");
			//Convert from curly braces xml back to regular xml
			string result = step6.Replace("{", "<").Replace("}", ">");
			Console.WriteLine(result);
			Console.WriteLine("Press enter to exit...");
			Console.ReadLine();
		}
		/// <summary>
		/// Matches the MatchEvaluator signature.
		/// </summary>
		private static string ReplaceMatch(Match match)
		{
			string contentWithoutAngularBrackets = match.Groups[1].Value;
			return "{" + contentWithoutAngularBrackets + "}";
		}
	}
