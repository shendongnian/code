    public class SplashScreenNotifier : IProcessNotifier 
    {
    	// Your SplashScreen must have a ViewModel. Let's say it is of type 'SplahScreenViewModel'
    	public SplashScreenNotifier(SplahScreenViewModel viewModel)
    	{
    		if (viewModel == null)
    			throw new ArgumentNullException("viewModel");
    			
    		this.ViewModel = viewModel;
    	}
    	
    	private SplahScreenViewModel ViewModel {get; set;}
    	
    	public void AppendNotification(string source, string details)
    	{
    		// Since you implement MVVM, let's say the 'InfoLine' property is bound to your UI splashscreen Label
    		this.ViewModel.InfoLine = string.Format("Processing '{0}' for '{1}'", source, details);
    	}
    }
