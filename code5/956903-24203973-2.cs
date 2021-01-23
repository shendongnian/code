	public static class ExceptionExtensions
	{
		/// <summary>
		/// Return a compact exception format for logging
		/// </summary>
		/// <remarks>
		/// In a single line the exception will contains the most relevant information like
		/// Excepition type and message, the call stack methods and lines
		/// Note: call stack is only available in Debug, Release will not contain these information
		/// </remarks>
		/// <param name="ex"></param>
		/// <returns></returns>
		/// <example>System.NotImplementedException: NotImplementedException (OwnLib.WoohooClass.ThisIsTheBestMethodEver()[13] => ConsoleApplication1.OwnClass.CallMeAClass()[13] => ConsoleApplication1.Program.Second(System.TimeSpan)[68] => ConsoleApplication1.Program.First()[57] => ConsoleApplication1.Program.Main(System.String[])[25])</example>
		public static string ToCompactString(this Exception ex)
		{
			var stack = new List<string>();
			var stackTrace = new StackTrace(ex, true);
			for (int i = 0; i < stackTrace.FrameCount; i++)
			{
				StackFrame sf = stackTrace.GetFrame(i);
				var method = sf.GetMethod();
				stack.Add(string.Format("{0}[{1}]", 
					method.ToString().SubstringFromMatch(method.Name, true).Replace(method.Name, string.Format("{0}.{1}", method.ReflectedType.FullName, method.Name)), 
					sf.GetFileLineNumber()));
			}
			return string.Format("{0}: {1} ({2})", ex.GetType(), ex.Message, stack.GetDelimiterSeperatedList(" => "));
		}
	}
	//Helper methods
	public static class StringExtensions
	{
		/// <summary>
		/// Substring for a searched string. takes the whole string from the match and cuts before.
		/// </summary>
		/// <param name="searchString">string to search within</param>
		/// <param name="searchedString">string to search for</param>
		/// <param name="includeMatch"><c>true</c> = with searchString, <c>false</c> = without</param>
		/// <param name="count">which time to found (0 = first)</param>
		/// <returns>a substring for a match, the whole string when no match</returns>
		public static string SubstringFromMatch(this string searchString, string searchedString, bool includeMatch, int count = 0)
		{
			if (searchString.Contains(searchedString))
			{
				var index = searchString.IndexOf(searchedString, count, StringComparison.Ordinal) + (includeMatch ? 0 : searchedString.Length);
				return searchString.Substring(index, searchString.Length - index);
			}
			return searchString;
		}
		/// <summary>
		/// Returns a list auf values, concatted by a delimiter like ",", e.g. "1,2,abc,cde"
		/// </summary>
		/// <remarks>a maximum of 999 items could be seperated</remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="delimiter">a delimiter used to seperate the items</param>
		/// <example>"," => "item1,item2,item3"; " - " "item1 - item2 - item3"</example>
		public static string GetDelimiterSeperatedList<T>(this ICollection<T> list, string delimiter)
		{
			if (list != null && list.Count > 0)
			{
				var seperatedList = String.Empty;
				var listCounter = 0;
				foreach (var id in list)
				{
					seperatedList += String.Format("{0}{1}", id, delimiter);
					if (listCounter++ >= 999) break;
				}
				return seperatedList.Remove(seperatedList.LastIndexOf(delimiter, StringComparison.Ordinal));
			}
			return null;
		}
	}
