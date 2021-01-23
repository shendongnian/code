    public class MainWindowViewModel : NotifierBase
    {
        private bool someProperty;
        public bool SomeProperty 
        {
            get
            {
                return this.someProperty;
            }
            set
            {
                if (this.someProperty != value)
                {
                    this.someProperty = value;
                    this.OnPropertyChanged();
                }
            }
        }
        public new event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
