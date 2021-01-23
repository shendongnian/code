    namespace WpfApplication8
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            employmentApplication  emp = new employmentApplication();  
    
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = emp;  
            }
        }
        public class employmentApplication:INotifyPropertyChanged
        {
            private byte appType = 0; // 1 = normal; 2 = expedited
    
            public byte AppType
            {
                get { return appType; }
                set
                {
                    appType = value;
                    this.OnPropertyChanged("AppType");
                }
            }
    
          
    
            public event PropertyChangedEventHandler PropertyChanged;          
    
            void OnPropertyChanged(string propName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(
                    this, new PropertyChangedEventArgs(propName));
            }
        }
    }
