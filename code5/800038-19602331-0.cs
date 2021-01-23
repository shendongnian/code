        private GroupAndCorrespondingEffect _selectedGroup;
        public GroupAndCorrespondingEffect SelectedGroup
        {
            get
            {
                return _selectedGroup;
            }
            set
            {
                _selectedGroup = value;
                OnPropertyChanged("SelectedGroup");
            }
        }
