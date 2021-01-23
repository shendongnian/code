    public class MainView
    {
       public MainView()
       {
          InitializeComponent();
          var userViewModel = new UserScreenViewModel();
          this.DataContext = userViewModel();
          var newClass = new NewClass(userViewModel);
       }
    }
