    public class LinesDataSource : INotifyPropertyChanged
    {
        private BindingList<string> lines = new BindingList<string>();
        public LinesDataSource()
        {
            lines.ListChanged += (sender, e) => OnPropertyChanged("LinesArray");
        }
        public BindingList<string> Lines
        {
            get { return lines; }
        }
        public string[] LinesArray
        {
            get
            {
                return lines.ToArray();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
