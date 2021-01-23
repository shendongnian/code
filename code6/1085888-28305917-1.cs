	public class Location
	{
		public X ObjectInLocation{get;set;}
	}
	public YourClass
	{
		public ThisIsAnObjectOfTheArray ThisIsAnObjectOfTheArray{get;set;}
	}
	public class Activity
	{
		public Location Location{get;set;}
		public ImageReference ImageReference{get;set;}
		public IList<YourClass> ThisIsAnArrayOfObjects{get;set;}
	}
