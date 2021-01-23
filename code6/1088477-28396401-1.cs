    public abstract class BasePage: Page
    {
    	public object SafeEval(object container, string expression)
    	{
    		try
    		{
    			return DataBinder.Eval(container, expression);
    		}
    		catch (HttpException e)
    		{
    			// Write error details to minimize the harm caused by suppressed exception 
    			Trace.Write("DataBinding", "Failed to process the Eval expression", e);
    		}
    
    		return "Put here whatever default value you want";
    	}
    }
