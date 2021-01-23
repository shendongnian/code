    public class VM
    {
        public VM()
        {
            this._aItems = new ObservableCollection<VMA>();
        }
        private ObservableCollection<VMA> _aItems;
        public Collection<VMA> AItems
        {
            get { return this._aItems; }
        }
    }
    public class VMA
    {
        public VMA()
        {
            this._bItems = new ObservableCollection<VMB>();
        }
        public string Title { get; set; }
        private ObservableCollection<VMB> _bItems;
        public Collection<VMB> BItems
        {
            get { return this._bItems; }
        }
    }
    public class VMB : INotifyPropertyChanged
    {
        public string Title { get; set; }
        private string _value;
        public string Value
        {
            get { return this._value; }
            set
            {
                if (this._value != value)
                {
                    this._value = value;
                    this.OnPropertyChanged("Value");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(
                    this,
                    new PropertyChangedEventArgs(name)
                    );
            }
        }
    }
