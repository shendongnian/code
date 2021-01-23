    public class Language : INotifyPropertyChanged
    {
        public static Language Instance { get; private set; }
        static Language() { Instance = new Language(); }
        private Language() { }
    
        private string name = "Name";
        public string Name
        {
            get { return name; }
            set { SetValue(ref name, value);}
        }
        protected void SetValue<T>(ref T field, T value,
            [CallerMemberName]string propertyName=null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName);
            }
        }
        protected virtual void OnPropertyChanged(
            [CallerMemberName]string propertyName=null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
