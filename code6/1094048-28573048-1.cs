    public class PersonFilter:  IComparable<PersonFilter>
    {
    	public int? MinAge { get; set; }
    	
    	public int? MaxAge { get; set; }
    	
    	public string NamePrefix { get; set; }
    	
    	public Expression<Predicate<Person>> Filter
    	{
    		return people => people.Where(person => (!MinAge.HasValue || person.Age > MinAge.Value) && 
    			(!MaxAge.HasValue || person.Age < MaxAge.Value) && 
    			(string.IsNullOrEmpty(NamePrefix) || person.FullName.StartsWith(NamePrefix))
    	}
    	
    	// -1 if this filter is filtering more than the other
    	public int CompareTo(PersonFilter other)
    	{
    		var balance = 0; // equal
    		if(MinAge.HasValue != other.MinAge.HasValue)
    		{
    			balance += MinAge.HasValue ? -1 : 1;
    		}
    		else if(MinAge.HasValue)
    		{
    			balance += MinAge.Value.CompareTo(other.MinAge.Value) ?
    		}
    		if(string.IsNullOrEmpty(NamePrefix) != string.IsNullOrEmpty(other.NamePrefix))
    		{
    			balance += string.IsNullOrEmpty(NamePrefix) ? -1 : 1;
    		}
    		else if(!string.IsNullOrEmpty(NamePrefix))
    		{
    			if(NamePrefix.StartsWith(other.NamePrefix))
    			{
    				balance -= 1;
    			}
    			else if(other.NamePrefix.StartsWith(NamePrefix))
    			{
    				balance += 1;
    			}
    			else
    			{
    				// if NamePrefix is the same or completely different let's assume both filters are equal
    			}
    		}
    		return balance;
    	}
		public bool IsSubsetOf(PersonFilter other)
		{
			if(MinAge.HasValue != other.MinAge.HasValue)
			{
				if(other.MinAge.HasValue)
				{
					return false;
				}
			}
			else if(MinAge.HasValue && MinAge.Value < other.MinAge.Value)
			{
				return false;
			}
    	
			if(string.IsNullOrEmpty(NamePrefix) != string.IsNullOrEmpty(other.NamePrefix))
			{
				if(!string.IsNullOrEmpty(other.NamePrefix))
				{
					return false;
				}
			}
			else if(!string.IsNullOrEmpty(NamePrefix))
			{
				if(!NamePrefix.StartsWith(other.NamePrefix))
				{
				return false;
				}
			}
    	
			return true;
		}
    }
