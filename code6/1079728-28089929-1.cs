    partial class MainPage
    {
       public MainPage()
       {
          InitializeComponent();
          Application.Current.Resuming += new EventHandler<Object>(App_Resuming);
       }
       private void App_Resuming(Object sender, Object e)
       {
          //Refresh app/view/data
       }
    }
   
