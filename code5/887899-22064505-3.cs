    using System.ComponentModel;
    
    namespace WpfApplication
    {
        public partial class MainWindow : INotifyPropertyChanged
        {
            private double _controlWidth = 100d;
    
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
            }
    
            public double ControlWidth
            {
                get { return _controlWidth; }
                set { _controlWidth = value; OnPropertyChanged("ControlWidth"); }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) 
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
