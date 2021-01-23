        private DataTable _aTable;
        public DataTable aTable
        {
            get
            {
                return _aTable;
            }
            set
            {
                _aTable= value;
                RaisePropertyChanged("aTable");
            }
        }
