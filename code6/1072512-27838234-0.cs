    public class YourClass : INotifyPropertyChanged
    {
        private Boundie _boundie;
        // You need Boundie to be public
        public Boundie 
        { 
            get; 
            set
            {
                 _boundie = value;
                 OnPropertyChanged("Boundie");
            } 
        }
 
        public Main()
        {
            Boundie = new Something { SomeProp = "old" };
            // Initialize component AFTER you initialized your attribute
            InitializeComponent();
            DataContext = this;
        }
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
        
