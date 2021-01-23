    public class SomeViewModel : ViewModelBase
    {
    	public Common CommonData { get; private set; }
    
    	public SomeViewModel()
    	{
    		CommonData = Common.GetInstance();
    	}
    }
