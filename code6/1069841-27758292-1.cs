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
    }
