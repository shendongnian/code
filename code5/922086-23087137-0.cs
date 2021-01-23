    public class Transaction
    {
    	public char? source { get; set; }
    }
    
    
    public class CustomerValidator : AbstractValidator<Transaction>
    {
    	public CustomerValidator()
    	{
    		RuleFor(t => t.source)
    			.Must(IsValidSource);
    	}
    	
    	
    	private bool IsValidSource(char? source)
    	{
    		if (source == 'I' || source == 'M' || source == null)
    			return true;
    		return false;                    
    	}
    }
