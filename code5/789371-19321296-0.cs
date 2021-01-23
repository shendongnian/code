    public class User : ICreatable 
    {
        [Key]
        public int Id { get; set; }
    
        ...
    
        public int CreatedByUserId 
    	{ 
    		get 
    		{
    			if (!_CreatedByUserId.HasValue)
    				//throw new exception, something went wrong.
    
    			return _CreatedByUserId;
    		}		
    		set 
    		{
    			_CreatedByUserId = value;
    		}
    	}
    	
    	int? _CreatedByUserId { get; set; }
    }
