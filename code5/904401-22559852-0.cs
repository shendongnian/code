    private string _selectedSearch;
        public string SelectedSearch
        {
            get { return _selectedSearch; }
            set
            {
                _selectedSearch = value;
                setSearch(_searchValue);
                RaisePropertyChanged(() => SelectedSearch);
            }
        }
    private void setSearch(string searchValue){ // to do }
