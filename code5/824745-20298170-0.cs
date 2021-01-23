    public class Person
    {
    	private static readonly CompiledExpressionMap<Employee, string> FullNameExpr =
    		DefaultTranslationOf<Employee>.Property(e => e.FullName).Is(e => e.FirstName + " " + e.LastName);
    
    	public string FirstName { get; set; }
    
    	public string LastName { get; set; }
    
    	[NotMapped]
    	public string FullName
    	{
    		get
    		{
    			return FullNameExpr.Evaluate(this);
    		}
    	}
    }
