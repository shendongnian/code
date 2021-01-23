    public class MyClass : INotifyPropertyChanged
    {
        public static ObservableCollection<double> m_selectedMarkers = new ObservableCollection<double>();
        public ObservableCollection<double> SelectedMarkers
        {
            get
            {
                return m_selectedMarkers;
            }
            set
            {
                m_selectedMarkers = value;
                NotifyPropertyChanged();
            }
        }
        private static MyClass m_Instance;
        public static MyClass Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new MyClass();
                }
                return m_Instance;
            }
        }
        private MyClass()
        {
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
