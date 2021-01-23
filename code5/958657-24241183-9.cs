    public class ViewModel : INotifyPropertyChanged
    {
        private double myProperty = 30;
        public double MyProperty
        {
            get { return myProperty; }
            set
            {
                myProperty = value;
                RaisePropertyChanged("MyProperty");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
