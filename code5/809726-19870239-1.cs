	public class SpecialListJustForYou<T> : List<T>
	{
		public SpecialListJustForYou(int capacity):base(capacity){}
		public SpecialListJustForYou(IEnumerable<T> collection):base(collection){}
		public SpecialListJustForYou():base(){}
		
		// and here's the magic!
		public SpecialListJustForYou(params T[] items) : base(items == null ? Enumerable.Empty<T>() : items.AsEnumerable()){}
	}
