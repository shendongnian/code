    public sealed class ViewModel : INotifyPropertyChanged
    {
        private object _derper;
        public event PropertyChangedEventHandler PropertyChanged = (o, e) => { };
        public object Derper
        {
            get { return this._derper; }
            set
            {
                this._derper = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Derper"));
            }
        }
        public ICommand OnDerp { get; set; }
        public ViewModel()
        {
            OnDerp = new DerpCommand(this);
        }
    }
