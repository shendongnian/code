    public class Customer
    {
    	private double ? _custAcct = null;
    	public double CustAcct
    	{
    		get
    		{
    			if (!_custAcct.HasValue)
    			{
    				_custAcct = GetCustAcct();
    			}
    
    			return _custAcct.Value;
    		}
    	}
    
    	private double GetCustAcct()
    	{
    		// do something that takes a long time
    		return 1234.45;
    	}
    }
