    public class CustomObject
    {
    	public string CategoryType { get; set; }
    	public string ActionNumber { get; set; }
    	public string KitNumber { get; set; }
    }
    //create Dummy Data
 	var source = new List<string>()
	{
		"PT01 0200LB  Wax  N011 00000000500030011 00000000",
		"PT02 0300LB  Bee  C011 00000000500030011 00000000",
		"PT03 0300LB  Silk  A011 00000000500030011 00000000",
		"PT04 0400LB  Cornflakes  A011 00000000500030011 00000000"
	};
	
	var result = from s in source
				 select new CustomObject {
				 	CategoryType = s.Substring(0,2),
					ActionNumber = s.Substring(2,3),
                    //read to end
					KitNumber = s.Substring(5, s.Length -6)
				 };
