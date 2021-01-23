    public abstract class BaseGateAction
    {
        ....	
    	public void PerformBaseActionWithPrecondition(Func<bool> precondition, Action actionToPerformWhileGateIsOpen)
    	{
    		if (precondition())
    		{
    			PerformBaseAction(actionToPerformWhileGateIsOpen);
    		}
    		else
    		{
    			Console.WriteLine("The gate could not be opened!");
    		}
    	}
        ...
    }
