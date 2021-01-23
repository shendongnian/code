    public class MainViewModel
    {
    	public MainViewModel
    	{
    		MyControlViewModel = new MyControlViewModel();
    		MyControlViewModel.OnTextboxOrComboBoxChanged += (sender, e) =>
    		{
    			IsButtonEnabled = false;
    			// add other process here
    		};
    	}
    	
    	public bool IsButtonEnabled { get; set; }
    	
    	public MyControlViewModel MyControlViewModel { get; set; }
    }
