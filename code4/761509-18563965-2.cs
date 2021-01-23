    foreach (Person p in list.People)
    {
    	if(p is Employee)
    	{
    	  Employee employee = p as Employee;
    	
          Debug.WriteLine(employee.salary.toString());
    	}
    	
    	if(p is Guest)
    	{
    	  Guest guest = p as Guest;		
    	
    	  Debug.WriteLine(guest.Id.toString());
    	}
    }
