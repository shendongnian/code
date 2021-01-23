		public string ImageUrlBase {get;set;}
		public List<MyItem> Items {get;set;}
	}
	public class MyItem
	{
		public string ImageUrlSuffix {get;set;}
		public string Name {get;set;}
		public string Description {get;set;}
		
		public MyItems Parent { get; set; }
		
		public string ImageUrl
		{
			get
			{
				return Parent.ImageUrlBase + ImageUrlSuffix;
			}
		}
	}
