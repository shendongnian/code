    private class MyInteger
    {
    	public int Value;
    	public bool Available;
    	public void MyInteger(int value, bool available)
    	{
    		Value = value;
    		Available = available;
    	}
    }
    public class IntegerPool
    {
    	private IList<MyInteger> _integers = new List<MyInteger>();
    
    	public void IntegerPool(List<int> startingCollection)
    	{
    		startingCollection.Sort();
    
    		foreach (var integer in startingCollection)
    		{
    			_integers.Add(new MyInteger(integer, true));
    		}
    	}
    
    	public int GetFirstAvailable()
    	{
    		foreach (var integer in _integers)
    		{
    			if (integer.Available)
    			{
    				integer.Available = false;
    				return integer.Value;
    			}
    		}
    
    		throw new Exception("No more integers available.");
    	}
    
    	public IList<int> GetAllAvailable()
    	{
    		var list = new List<int>();
    		foreach (var integer in _integers)
    		{
    			if (integer.Available)
    				list.Add(integer.Value);
    		}
    
    		return list;
    	}
    
    	public int? TryGetSpecific(int specific)
    	{
    		foreach (var integer in _integers)
    		{
    			if (integer.Value == specific)
    			{
    				if (!integer.Available)
    					return null;
    
    				integer.Available = false;
    				return integer.Value;
    			}
    		}
    
    		throw new Exception("Integer not in collection.");
    	}
    
    	public void ReleaseInteger(int integerToBeReleased)
    	{
    		foreach (var integer in _integers)
    		{
    			if (integer.Value == integerToBeReleased)
    			{
    				integer.Available = true;
    				return;
    			}
    		}
    	}
    }
