    private bool _isactive;
        public bool IsActive
        {
            get { return _isactive; }
            set
            {
                _isactive = value;
                RaisePropertyChanged(() => IsActive);
            }
        }
