        public class MyObj
    	{
		    public string MyStr{get;set;}
	    }
	    var myObj  = new List <MyObj>
		{ 
			new  MyObj{ MyStr="1,2,3,4,5"},
			new  MyObj{ MyStr="9,2,3,4,5"}
		};
		var num =9;
		var searchResults = from obj  in myObj
							where !string.IsNullOrEmpty(obj.MyStr) &&  
                                  obj.MyStr.Split(new []{','})
                                           .Contains(num.ToString())
							select obj;
		foreach(var item in searchResults)							 
	        Console.WriteLine(item.MyStr);
