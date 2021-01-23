    public class Person
    {
    	public int Id { get; set; }
    
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    
    	public int Age { get; set; }
    
    	public Company Company { get; set; }
    
    	public static Expression<Func<Person, string>> FirstNameExpression
    	{
    		get { return x => x.FirstName; }
    	}
    
    	public static Expression<Func<Person, string>> LastNameExpression
    	{
    		get { return x => x.LastName; }
    	}
    
    	public static Expression<Func<Person, string>> FullNameExpression
    	{
    		//get { return FirstNameExpression.Plus(" ").Plus(LastNameExpression); }
    		// or
    		get { return x => FirstNameExpression.Wrap(x) + " " + LastNameExpression.Wrap(x); }
    	}
    
    	public static Expression<Func<Person, string>> SearchFieldExpression
    	{
    		get
    		{
    			return
    				p => string.IsNullOrEmpty(FirstNameExpression.Wrap(p)) ? LastNameExpression.Wrap(p) : FullNameExpression.Wrap(p);
    		}
    	}
    
    	public static Expression<Func<Person, bool>> GetFilterExpression(string q)
    	{
    		return p => SearchFieldExpression.Wrap(p) == q;
    	}
    }
