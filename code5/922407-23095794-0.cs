    class Order : INotifyPropertyChanged
    {
        // Boilerplate code..
        private bool _Visible ;
        public bool Visible
        {
            get { return _Visible; }
            set
            {
                if (_Visible == value) return;
                _Visible = value;
                OnPropertyChanged(() => _Visible);
            }
        }
    }
