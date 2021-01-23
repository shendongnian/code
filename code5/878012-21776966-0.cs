    // Main viewModel
    public MainViewModel : ViewModelBase
    {
    	...
    	// EventArgs<T> inherits from EventArgs and contains a EventArgsData property containing the T instance
    	public event EventHandler<EventArgs<MyPopupViewModel>> ConfirmationRequested;
    	...
    	// Called when ICommand is executed thanks to RelayCommands
    	public void DoSomething()
    	{
    		if (this.ConfirmationRequested != null)
    		{
    			var vm = new MyPopupViewModel
    			{
    				// Initializes property of "child" viewmodel depending
    				// on the current viewModel state
    			};
    			this.ConfirmationRequested(this, new EventArgs<MyPopupViewModel>(vm));
    		}
    	}
    }
    ...
    // Main View
    public partial class MainWindow : Window
    {
    	public public MainWindow()
    	{
    		this.InitializeComponent();
    		
    		// Instantiates the viewModel here
    		this.ViewModel = new MainViewModel();
    		
    		// Attaches event handlers
    		this.ViewModel.ConfirmationRequested += (sender, e) =>
    		{
    			// Shows the child Window here
    			// Pass the viewModel in the constructor of the Window
    			var myPopup = new PopupWindow(e.EventArgsData);
    			myPopup.Show();			
    		};
    	}
    	
    	public MainViewModel ViewModel { get; private set; }
    }
    
    // App.xaml, starts MainWindow by setting the StartupUri
    <Application x:Class="XXX.App"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    			 ...
                 StartupUri="Views/MainWindow.xaml">
