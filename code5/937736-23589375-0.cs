namespace Utility
{
	public class StringUtil
	{
		public static bool Contains(string source, string toCheck, StringComparison comp)
		{
		  return source.IndexOf(toCheck, comp) >= 0;
		}
	}
}
using Utility.StringUtil;
//call function
Contains(....);
or
using Utility;
//call function
StringUtil.Contains(....);
