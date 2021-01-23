	public class Location
	{
		public X ObjectInLocation{get;set;}
	}
	public ImageReference
	{
		public int Id{get;set;}
		public string ImageUrl{get;set;}
	}
	public class Activity
	{
		public Location Location{get;set;}
		public IEnumerable<ImageReference> ImageReferences{get;set;}
		
	}
