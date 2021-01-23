    class ViewModel : INotifyPropertyChanged
    {
        private string path;
        public string Path
        {
            get { return path; }
            set {
                if (value != path)
                {
                    path = value;
                    NotifyPropertyChanged();
                }
            }
        }
        // This event gets triggered whenever a property changes.
        public event PropertyChangedEventHandler PropertyChanged;
        // This will cause the event to actually be triggered. It automatically determines the name of the property that triggered it using the [CallerMemberName] attribute - just a bit of .NET 4.5 sweetness. :)
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
