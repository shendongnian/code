    public class Something
    {
        public int Test1 { get; set; }
        public int Test2 { get; set; }
        public int Test3 { get; set; }
        public int Test4 { get; set; }
    }
    var thing = new Something();
    var imageProperties = typeof(Something)
        .GetProperties()
        .Where(p => p.Name.StartsWith("Test"));
	
    var imagesToAdd = imageProperties
        .Select(property => property.GetValue(thing))
        .ToList();
