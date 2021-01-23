    using System;
    using System.Web;
    using System.Net;
					
	public static void Main()
	{
		var url = "https://www.youtube.com/watch?v=NHfWY0is3rE";
		string name = GetTitle(url);
		Console.WriteLine(name);
	}
	
	public static string GetTitle(string url)
	{
		var api = $"http://youtube.com/get_video_info?video_id={GetArgs(url, "v", '?')}";
    	return GetArgs(new WebClient().DownloadString(api), "title", '&');
	}
	private static string GetArgs(string args, string key, char query)
	{
    	var iqs = args.IndexOf(query);
    	return iqs == -1
			? string.Empty
			: HttpUtility.ParseQueryString(iqs < args.Length - 1
				? args.Substring(iqs + 1) : string.Empty)[key];
	}
