    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string display;
        // Implement INotifyPropertyChanged
        // This should be done by Commands, actually
        public void Nine(Object sender, RoutedEventArgs e)
        {
            Display += "9";
        }
        public string Display
        {
            get
            {
                return display;
            }
            set
            {
                display = value;
                if (NotifyPropertyChanged != null)
                    NotifyPropertyChanged(this, new PropertyChangedEventArgs("Display");
            }
        }
    }
