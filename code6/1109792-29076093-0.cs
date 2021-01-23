	class Program
	{
		static void Main(string[] args)
		{
			HtmlDocument doc = new HtmlDocument();
			doc.Load("Demo.html");
			var result = doc.DocumentNode.SelectNodes("//table")
				.Select(table => new //create anonymous type
				                 {
					                 Table = table,
									 HeaderNodes = table.SelectNodes("./tbody/tr/th").ToList() //the th subnodes
				                 });
			foreach (var table in result)
			{
				foreach (HtmlNode headerNode in table.HeaderNodes)
				{
					Console.WriteLine( headerNode.InnerText);
				}
				Console.WriteLine("--------------------------");
			}
		}
	}
