    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        TimeSpan measure_gap = TimeSpan.FromSeconds(1); //init
        public double Measure_gap
        {
            get
            {
                return measure_gap.TotalSeconds;
            }
            set
            {
                if (value != measure_gap.TotalSeconds)
                {
                    measure_gap = TimeSpan.FromSeconds(value);
                    OnPropertyChanged("Measure_gap");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
 
