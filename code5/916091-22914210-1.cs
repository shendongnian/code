    class ViewModel : INotifyPropertyChanged
    {
        private object _selected;
        private object _result;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<object> Items { get; private set; }
        public object Selected
        {
            get { return this._selected; }
            set
            {
                if (_selected == value)
                    return;
                this._selected = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Selected"));
            }
        }
        public object Result
        {
            get { return this._result; }
            set
            {
                if (_result == value )
                return;
                this._result = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Result"));
            }
        }
        public ViewModel()
        {
            Items = new ObservableCollection<object>();
            Items.Add(1);
            Items.Add("hello");
            Items.Add(3.0d);
            PropertyChanged += OnPropertyChanged;
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Selected")
                return; 
            //DO MASSIVE WORK HER ON BACKGROUND THREAD OR SOMETHING LOL
            Result = "OMG THIS TOOK A LONG TIME, " + Selected.ToString();
        }
    }
