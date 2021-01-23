        public IEnumerable BoundList
        {
            get { return _boundList; }
            set
            {
                _boundList = value;
                OnPropertyChanged("BoundList");
            }
        }
        public void CommandExecuted()
        {
            BoundList = _boundList == _firstCollection ? (IEnumerable)_SecondCollection : _firstCollection;
        }
