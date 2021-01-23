    public partial class MainWindow : Window
    {
        private ExampleViewModel m_ViewModel;
        public MainWindow()
        {
            InitializeComponent();
            m_ViewModel = new ExampleViewModel();
            DataContext = m_ViewModel;
        }
    }
    public class ExampleViewModel : INotifyPropertyChanged
    {
        private string m_Name = "Type Here";
        public ExampleViewModel()
        {
        }
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Name can not be empty.");
                }
                if (value.Length > 12)
                {
                    throw new Exception("name can not be longer than 12 charectors");
                }
                if (m_Name != value)
                {
                    m_Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
