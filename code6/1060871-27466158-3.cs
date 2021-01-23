    public class Day
	{
		public string morning_low { get; set; }
		public string daytime_high { get; set; }
	}
	
	public class ResultContent
	{
		public dynamic data { get; set; }
	}
	
	public class ResultContentRoot
	{
		public ResultContent result_content { get; set; }
	}
	
	public static void Main()
	{
		dynamic data = new ExpandoObject();
		data.city_name = "New York";
		IDictionary<string, object> days = (IDictionary<string, object>)data;
		days.Add(DateTime.Today.ToString("yyyy-MM-dd'T'HH:mm:ss"), new Day() { morning_low = "24", daytime_high = "29" });
        
		var result_content = new ResultContent();
		result_content.data = data;
		
		var root = new ResultContentRoot();
		root.result_content = result_content;
		
        var s = JsonConvert.SerializeObject(root);
	}
