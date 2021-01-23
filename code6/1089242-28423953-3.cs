    public void Main()
    {
        var x = new InheritedAction();
    }
    public abstract class BaseGateAction
    {
    	public void PerformBaseAction(Action actionToPerformWhileGateIsOpen)
    	{
    		Open();
    		actionToPerformWhileGateIsOpen();
    		Close();
    	}
    	
    	private void Open()
        {
            Console.WriteLine("Gate has been opened");
        }
    
    	private void Close()
    	{
    		Console.WriteLine("Gate has been closed");
    	}
    }
    
    public class InheritedAction : BaseGateAction
    {
    	public InheritedAction()
    	{
    		PerformBaseAction(() => 
                Console.WriteLine("Attack the dragon while the gate is open"));
    		
    		PerformBaseAction(() => 
    		{
    			Console.WriteLine("Attack the dragon while the gate is open");
    			Console.WriteLine("The dragon is victorious and you have been devoured");
    		});
    	}
    }
