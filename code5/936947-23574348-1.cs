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
    	
    	public SortedState State()
    	{
    		return state;
    	}
    	
    	public bool? Unique()
    	{
    		return state == SortedState.Mixture ? (bool?)null : uniqueValues;
    	}
    	
    	public override string ToString()
    	{
    		return string.Format(
    			"{0} ({1})",
    			State(),
    			Unique().HasValue ? (Unique().Value ? "unique" : "not unique")
    				: "unknown uniqueness");
    	}
    };
    
    static void CheckIfSorted<T>(IEnumerable<T> values) where T : IComparable<T>
    {
    	Console.WriteLine(
    		values.Aggregate(
    			new AscOrDescHelper<T>(),
    			(last, next) => last.ProcessNextValue(next)));
    }
    
    static void Main()
    {
    	CheckIfSorted(new string[]{ "amy", "kate", "sally" });
    	CheckIfSorted(new int[]{ 7, 5, 5 });
    	CheckIfSorted(new int[]{ 2, 3, 1 });
    	// Gives:
    	//   Ascending (unique)
    	//   Descending (not unique)
    	//   Mixture (unknown uniqueness)
    }
