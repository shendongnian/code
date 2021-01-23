    public class BackgroundColorItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            var localEvent = PropertyChanged;
            if (localEvent != null)
            {
                localEvent.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (string.Equals(title, value))
                {
                    return;
                }
                title = value;
                RaisePropertyChanged("Title");
            }
        }
        private Brush brush;
        public Brush Brush
        {
            get
            {
                return brush;
            }
            set
            {
                if (Brush.Equals(brush, value))
                {
                    return;
                }
                brush = value;
                RaisePropertyChanged("Brush");
            }
        }
    }
