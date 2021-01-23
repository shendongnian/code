        public ICommand LoadSegmentCommand
        {
            get { return new RelayCommand<int>(OnLoadSegmentCommandCommandReceived); }
        }
        private void OnLoadSegmentCommandCommandReceived(int segment)
        {
            // Assign the data to Observable Collection
        }
