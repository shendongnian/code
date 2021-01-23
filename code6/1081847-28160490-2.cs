    public class ViewModel
    {
    	public static Object Lock = new Object();
    }        
    public void Update()
    {
    	lock (ViewModel.Lock)
    	{
    		//Perform updates
    	}
    }
