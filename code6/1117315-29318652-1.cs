    public class MainViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<string> ChartTypes { get; set; }
    
            public MainViewModel()
            {
                ChartTypes = new ObservableCollection<string>();      
                ChartTypes.Add("Pie");
                ChartTypes.Add("Doughnut");
              
            }
    
            private string _simpleStringProperty;
            public string SimpleStringProperty
            {
                get { return _simpleStringProperty; }
                set
                {
                    _simpleStringProperty = value;
                    if (value.Equals("Pie"))
                    {
                        SelectedPageChart = new Uri("PageTest.xaml", UriKind.Relative);
                    }
                    if (value.Equals("Doughnut"))
                    {
                        SelectedPageChart = new Uri("PageTest2.xaml", UriKind.Relative);
                    }
                    OnPropertyChanged("SimpleStringProperty");
                    
                }
            }
    
            private Uri _selectedPageChart;   
            public Uri SelectedPageChart
            {
                get { return _selectedPageChart; }
                set
                {
                    _selectedPageChart = value;
                    OnPropertyChanged("SelectedPageChart");
                }
            }
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
