    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public string SomeProperty
        {
            get
            {
                return _someProperty;
            }
            set
            {
                if (_someProperty != value)
                {
                    _someProperty = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("SomeProperty"));
                    }
                }
            }
        }
        string _someProperty;
        void OnSourceUpdated(object sender, DataTransferEventArgs e)
        {
            var textbox = (TextBox) sender;
            string message = string.Format(
                "Property value is '{0}' and was changed by TextBox '{1}'",
                SomeProperty, textbox.Name);
            Console.WriteLine(message);
        }
    }
