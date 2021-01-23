    public partial class ClassBlock: UserControl, INotifyPropertyChanged
    {        
        private string classInstance;
        public ClassBlock()
        {
            this.InitializeComponent();
        }
        public string ClassInstance
        {
            get
            {
                return this.classInstance;
            }
            set
            {
                this.classInstance= value;
                this.OnPropertyChanged();
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                // Invoke the event handlers attached by other objects.
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
