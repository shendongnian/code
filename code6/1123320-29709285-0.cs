	using System;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	namespace parseWiki
	{
		class Program
		{
			static void Main(string[] args)
			{
				string content = @"|| Owner || Action || Status || Comments || | Bill\\ | fix the lobby |In Progress | This is eary| | Joe\\ |fix the bathroom\\ | In progress| plumbing  \\Electric \\Painting \\ \\ | | Scott \\ | fix the roof \\ | Complete | this is expensive|";
				content = content.Replace(@"\\", "");
				string headerContent = content.Substring(0, content.LastIndexOf("||") + 2);
				string cellContent = content.Substring(content.LastIndexOf("||") + 2);
				MatchCollection headerMatches = new Regex(@"\|\|([^|]*)(?=\|\|)", RegexOptions.Singleline).Matches(headerContent);
				MatchCollection cellMatches = new Regex(@"\|([^|]*)(?=\|)", RegexOptions.Singleline).Matches(cellContent);
				List<string> headers = new List<string>();
				foreach (Match match in headerMatches)
				{
					if (match.Groups.Count > 1)
					{
						headers.Add(match.Groups[1].Value.Trim());
					}
				}
				List<List<string>> body = new List<List<string>>();
				List<string> newRow = new List<string>();
				foreach (Match match in cellMatches)
				{
					if (newRow.Count > 0 && newRow.Count % headers.Count == 0)
					{
						body.Add(newRow);
						newRow = new List<string>();
					}
					else
					{
						newRow.Add(match.Groups[1].Value.Trim());
					}
				}
				body.Add(newRow);
				print(headers, body);
			}
			static void print(List<string> headers, List<List<string>> body)
			{
				var CELL_SIZE = 20;
				for (int i = 0; i < headers.Count; i++)
				{
					Console.Write(headers[i].Truncate(CELL_SIZE).PadRight(CELL_SIZE) + "  ");
				}
				Console.WriteLine("\n" + "".PadRight( (CELL_SIZE + 2) * headers.Count, '-'));
				for (int r = 0; r < body.Count; r++)
				{
					List<string> row = body[r];
					for (int c = 0; c < row.Count; c++)
					{
						Console.Write(row[c].Truncate(CELL_SIZE).PadRight(CELL_SIZE) + "  ");
					}
					Console.WriteLine("");
				}
				Console.WriteLine("\n\n\n");
				Console.ReadKey(false);
			}
		}
		public static class StringExt
		{
			public static string Truncate(this string value, int maxLength)
			{
				if (string.IsNullOrEmpty(value) || value.Length <= maxLength) return value;
				return value.Substring(0, maxLength - 3) + "...";
			}
		}
	}
