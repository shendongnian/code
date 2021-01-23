    void Main()
    {       //ignore Dump() method
	    var list = new List<ObjectA>() 
        {
	        new ObjectA("name1", true),
        	new ObjectA("name2", true),
	        new ObjectA("name3", null),
	        new ObjectA("name4", false),
	        new ObjectA("name5", null),
	        new ObjectA("name6", false),
	        new ObjectA("name7", true)
     	};
        //check if all Items are valid
	var allItems = list.All(m => m.Name.Contains("ss") && m.valid == true); // false
        //only get valid items (name contains name AND true)
	var validItems = list.Where (l => l.Name.Contains("name") && l.valid == true).Dump();
        //get all items which are invalid
	var nonvalidItems = list.Where(l =>!(l.Name.Contains("name")) || l.valid != true).Dump();
}
    public class ObjectA
    {
      public ObjectA(string name, bool? _val)
      {
        this.Name = name;
    	if(_val.HasValue)
    	  this.valid = _val;
      }
     public string Name { get; set; }
     public bool? valid { get; set; }
    }
