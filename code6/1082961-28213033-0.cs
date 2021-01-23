    public class VM : INotifyPropertyChanged
    {
		private ObservableCollection<string> _items;
        public ObservableCollection<string> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                _selectedItem = _items.FirstOrDefault();
                RaisePropertyChanged("Items");
                RaisePropertyChanged("SelectedItem");
            }
        }
        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }
        public VM()
        {
			this._items = new ObservableCollection<string>();
        }
        public async Task LoadDataAsync()
        {
			var items = new List<string>() {
                "1",
                "b",
                "c",
                "d",
                "e",
                "f",
                "f",
                "f",
                "f",
                "f",
                "f",
            };
			foreach (var i in items) {
				this._items.Add(i);
			}
			this.SelectedItem = items.FirstOrDefault();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
