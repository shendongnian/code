    foreach (A a in listOfA)
    {
    	var t = typeof(A);
    	List<object> list = new List<object>();
    
    	foreach (var prop in t.GetProperties())
    	{
    		list.Add(prop.GetValue(a));
    
    	}
    	newListOfA.Add(list);
    }
