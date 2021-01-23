    // uses System.ComponentModel
    public class YourViewModel : INotifyPropertyChanged
    {
        private double longitude;
        public double Longitude
        { 
            get { return longitude; }
            set
            {
                longitude = value;
                NotifyPropertyChanged("Longitude");
            }
        } 
        private double latitude;
        public double Latitude
        { 
            get { return latitude; }
            set
            {
                latitude= value;
                NotifyPropertyChanged("Latitude");
            }
        } 
    }
