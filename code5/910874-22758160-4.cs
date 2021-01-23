    class MyCollection : INotifyPropertyChanged
    {
        #region PROP Bar
        private byte _bar;
        public byte Bar
        {
            get { return this._bar; }
            set
            {
                if (this._bar != value)
                {
                    this._bar = value;
                    this.OnPropertyChanged("Bar");
                    Console.WriteLine("bar="+ this._bar);
                    this.UpdateItems();
                }
            }
        }
        #endregion
        public void UpdateItems()
        {
            //rebuild the children collection
            var collection = new List<MyWrapper>();
            for (int i = 0; i < 8; i++)
            {
                var item = new MyWrapper();
                item.Value = ((this._bar >> i) & 1) != 0;
                collection.Add(item);
            }
            this.Items = collection;
        }
        #region PROP Items
        private IEnumerable<MyWrapper> _items;
        public IEnumerable<MyWrapper> Items
        {
            get { return this._items; }
            set
            {
                if (this._items != value)
                {
                    this._items = value;
                    this.OnPropertyChanged("Items");
                    if (this._items != null)
                    {
                        foreach (var child in this._items)
                        {
                            child.PropertyChanged += child_PropertyChanged;
                        }
                    }
                }
            }
        }
        #endregion
        void child_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //rebuild the scalar value
            int value = 0;
            foreach (var item in this._items)
            {
                value = value >> 1;
                if (item.Value) value |= 0x80;
            }
            this.Bar = (byte)value;
        }
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
