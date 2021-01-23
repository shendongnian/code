	class Foo
	{
		public int PropertyOne { get; set; }
		public string PropertyTwo { get; set; }
	}
	var theList = new List<Foo> {
		// some foo go here	
	};
	var filtered = theList.Select(f=> new {PropertyOne = f.PropertyOne }).ToList();
