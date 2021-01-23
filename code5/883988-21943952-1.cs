    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new MainViewModel();  
     //In this case the HandleAppExitEvent and the subscriber that deals with this event.                   
     EventAggregatorHelper.Current.GetEvent<AppExitEvent>().   Subscribe(HandleAppExitEvent);  
        
                }
          //note that this method should be public 
     public void HandleAppExitEvent(string mess)
        {
           if (!String.IsNullOrEmpty(mess))
           {
              //Do whatever you need to do here.
           }
        }
        }
