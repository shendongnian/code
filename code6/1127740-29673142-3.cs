    public class Employee
    {
        public Company Company { get; set; }
    
    	private ContactMethods? preferredContactMethod;
        public ContactMethods? PreferredContactMethod 
    	{
    		get 
    		{ 
    			if (this.preferredContactMethod != null)
    			{
    				return this.preferredContactMethod;
    			}
    			else if (this.Company != null)
    			{
    				return this.Company.PreferredContactMethod;
    			}
    			else
    			{
    				return null;
    			}
    		}
    		set { this.preferredContactMethod = value; }
    	}
    }
