    class MyCollection
    {
        public IEnumerable<MyWrapper> Bar { get; set; }
    }
    class MyWrapper : INotifyPropertyChanged
    {
        #region PROP Value
        private bool _value;
        public bool Value
        {
            get { return this._value; }
            set
            {
                if (this._value != value)
                {
                    this._value = value;
                    this.OnPropertyChanged("Value");
                    Console.WriteLine("changed="+ this._value);
                }
            }
        }
        #endregion
        
        #region EVT PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(
                    this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
