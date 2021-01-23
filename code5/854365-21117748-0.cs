    namespace WPF1
    {
      public partial class MainWindow : Window
      {
        personalApp currentApplication = new personalApp ();
    
        public MainWindow()
        {
          InitializeComponent();
          this.DataContext = currentApplication;
        }
      }
    }
