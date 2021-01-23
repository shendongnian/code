    public static class Extensions
    {
       public static string ParseFromString(this string source, string start, string end)
       {
       		int From = source.IndexOf(start) + start.Length;
    		int To = source.LastIndexOf(end);
    		
    		string result = source.Substring(From, To - From);
    		return result;
       }
    }
