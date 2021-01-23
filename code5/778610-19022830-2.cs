    public class FooIdentifier
    {
    	private SubFoo InnerSubFoo { get; set; }
    	public FooIdentifier(SubFoo subFoo, string propertyC)
    	{
    		this.InnerSubFoo = subFoo
    		this.PropertyC = propertyC;
    	}	
    	
    	public virtual string PropertyA 
        { 
            get 
            { 
                return SubFoo.PropertyA; 
            } 
            set 
            {
                SubFoo.PropertyA = value; 
            }
        }
        
        public virtual string PropertyB
        {
            get
            {
                return SubFoo.PropertyB; 
            }
            set 
            {
                SubFoo.PropertyB = value;
            }
        }
    
        public virtual string PropertyC { get; set; }
    }
