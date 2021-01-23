    public abstract class ComponentController
    {
    	protected abstract void CreateCustomColumnsCore();
    }
    
    public abstract class ClientComponentController : ComponentController
    {
    	protected override void CreateCustomColumnsCore()
    	{
    		// your code here
    
    		CreateCustomColumns();	// call users' implementation
    	}
    
    	public abstract void CreateCustomColumns();
    }
    
    public class ClientInvoicesComponentController: ClientComponentController
    {
    	public override void CreateCustomColumns()
    	{
    		// user must implement this method.
    	}
    }
