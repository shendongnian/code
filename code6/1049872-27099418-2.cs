      public class MainView
      {
         public MainView()
         {
            InitializeComponent();
            this.ViewModel = new MainViewModel();
         }
    
         public MainViewModel ViewModel
         {
            get { return this.DataContext as MainViewModel; }
            set { this.DataContext = value; }
         }
    
         private void TeadIdText_TextChanged(object sender, TextChangedEventArgs e)
         {
             this.ViewModel.TeamID = TeamIdtxt.Text;        
         }
    
         private void Btn_Ok_Click(object sender, RoutedEventArgs e)
         {         
             this.ViewModel.GetPlayer();   
         }         
      }
