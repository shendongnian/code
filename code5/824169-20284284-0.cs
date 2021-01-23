    private class PersonEqualityComparer : IEqualityComparer<Person>
    {
    	public bool Equals(Person p1, Person p2)
    	{
    		// Compare the strings as needed (culture, casing, nulls, ...)
    		return p1.Name == p2.Name;
    	}
    	
    	public int GetHashCode(Person p)
    	{
            // Handle nulls as needed
    	    return p.Name.GetHashCode();
    	}
    }
