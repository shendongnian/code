	void Main()
	{
	var temp = @"
	{""root"": 
		{""ajaxResponse"": {
						""credits"": {""availableCredits"": 998,
						""total"": ""1000"",
						""used"":""2""
							},
						""success"": 1
							}
			}
	}
	";
		var outObject = JsonConvert.DeserializeObject<Root>(temp);
		outObject.Dump();
	}
	
	public class Container
	{
		public Root root {get;set;}
	}
	
	public class Root
	{
		public AjaxResponse ajaxResponse {get; set;}
	}
	
	
	public class Credits
	{
		public int availableCredits {get; set;}
		public string total {get; set;}
		public string used {get; set;}
	}
	
	public class AjaxResponse
	{
		public Credits credits {get; set;}
		public int success {get; set;}
	}
