    public class bill_staff : System.Windows.Forms.Form
    {
    
    	private static bill_staff _DefaultInstance;
    	public static bill_staff DefaultInstance
    	{
    		get
    		{
    			if (_DefaultInstance == null)
    				_DefaultInstance = new bill_staff();
    
    			return _DefaultInstance;
    		}
    	}
    }
    
    internal class testclass
    {
    	public void testmethod()
    	{
    		bill_staff.DefaultInstance.Show();
    	}
    }
