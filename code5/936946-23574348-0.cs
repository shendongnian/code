    public enum SortedState
    {
    	NoValues,
    	Undecided,
    	Ascending,
    	Descending,
    	Mixture
    };
    
    public class AscOrDescHelper<T> where T : IComparable<T>
    {
    	SortedState state;
    	T lastValue;
    	bool uniqueValues;
    	
    	public AscOrDescHelper()
    	{
    		state = SortedState.NoValues;
    		uniqueValues = true;	// tentative assumption
    	}
    	
    	public AscOrDescHelper<T> ProcessNextValue(T next)
    	{
    		switch (state)
    		{
    			case SortedState.NoValues:
    				state = SortedState.Undecided;
    				break;
    			case SortedState.Undecided:
    			case SortedState.Ascending:
    			case SortedState.Descending:
    				int cmp = next.CompareTo(lastValue);
    				switch (state)
    				{
    					case SortedState.Undecided:
    						if (cmp > 0)
    						{
    							state = SortedState.Ascending;
    						}
    						else if (cmp < 0)
    						{
    							state = SortedState.Descending;
    						}
    						else
    						{
    							uniqueValues = false;
    						}
    						break;
    					case SortedState.Ascending:
    						if (cmp < 0)
    						{
    							state = SortedState.Mixture;
    						}
    						else if (cmp == 0)
    						{
    							// Not unique
    							uniqueValues = false;
    						}
    						break;
    					case SortedState.Descending:
    						if (cmp > 0)
    						{
    							state = SortedState.Mixture;
    						}
    						else if (cmp == 0)
    						{
    							// Not unique
    							uniqueValues = false;
    						}
    						break;
    				}
    				break;
    		}
    		
    		lastValue = next;
    	
    		return this;
    	}
    	
    	public SortedState GetState()
    	{
    		return state;
    	}
    	
    	public string GetUnique()
    	{
    		return state == SortedState.Mixture ? "unknown uniqueness"
    			: uniqueValues ? "unique" : "not unique";
    	}
    };
    
    void Main()
    {
    	int[] ages = { 4, 5, 6 };
    	
    	Console.WriteLine(
    		ages.Aggregate(
    			new AscOrDescHelper<int>(),
    			(last, next) => last.ProcessNextValue(next),
    			final => string.Format(
    				"{0} ({1})",
    				final.GetState(),
    				final.GetUnique())));
    				
    	// prints: Ascending (unique)
    }
