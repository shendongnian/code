    public partial class MainWindow : Window, INotifyPropertyChanged
    {
            public MainWindow() {
                DataContext = this;
                InitializeComponent();
            }
            // ... 
            private Camera _camera;
            public Camera Camera;
            {
                get { return _camera; }
                set
                {
                    if (_camera != value)
                    {
                         _camera= value;
                         OnPropertyChanged("Camera");
                    }
    
                }
            }
    
            /// <summary>
            /// Raises the PropertyChanged notification in a thread safe manner
            /// </summary>
            /// <param name="propertyName"></param>
            private void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            #endregion
    }
