      private string _selectedMyList;
        public string SelectedMyList
        {
            get
            {
                return this._selectedMyList;
            }
            set
            {
                //value is always Hi
                if (this._selectedMyList != value)
                {
                    this._selectedMyList= value;
                    OnPropertyChanged("SelectedMyList");
                }
            }
        }
    
        private List<ObservableCollection> _myList;
        public ObservableCollection<string> MyList
        {
            get
            {
                return this._myList;
            }
            set
            {
                if (this._myList== value)
                {
                    this._myList= value;
                    OnPropertyChanged("MyList");
                }
            }
        }
