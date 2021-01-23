    public class MainViewModel : ViewModelBase
    {
    	private static MainViewModel Primary { get; set; }
    	
    	public MainViewModel()
    	{
    		Primary = this;
    	}
    	
    	public static void SwitchViewStatic()
    	{
    		Primary.SwitchView();
    	}
    	
    	public void SwitchView()
    	{
    	...
    	}
    	
    }
