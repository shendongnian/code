    namespace WpfApplication1
    {
      public partial class MainWindow : Window, INotifyPropertyChanged
      {
        public MainWindow()
        {
          InitializeComponent();
        }
    
        private DeploymentDto deployment = new DeploymentDto { Id = 2 };
        public DeploymentDto Deployment
        {
          get { return deployment; }
          set { deployment = value; OnPropertyChanged("Deployment"); }
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
          Deployment = new DeploymentDto { Id = new Random().Next(100) };
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propName)
        {
          if (PropertyChanged != null)
          {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
          }
        }
      }
    }
