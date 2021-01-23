    foreach (Person p in list.People)
    {
    	if(p is Employee)
    	{
    	  Debug.WriteLine(((Employee)p).salary.toString());
    	}
    	
    	if(p is Guest)
    	{
    	  Debug.WriteLine(((Guest)p).Id.toString());
    	}
    }
