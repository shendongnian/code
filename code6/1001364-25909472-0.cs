      private List<string> _MyComboBoxData;
        public List<string> MyComboBoxData
        {
            get
            {
                return _MyComboBoxData;
            }
            set
            {
                _MyComboBoxData = value;
                OnPropertyChanged(() => MyComboBoxData);
            }
        }
