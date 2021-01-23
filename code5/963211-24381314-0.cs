    class Customer
    {
    	public abstract SendDocumentsTo(Customer c);
    }
    
    
    class SpecificCustomerA
    {
    	public overwrite SendDocumentsTo(Customer c)
    	{
    		if (c is SpecificCustomerB)
    		{
    			//Logic here
    		}
    	}
    }
    
    class SpecificCustomerB { ... }
