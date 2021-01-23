    #region Search Functionality
        
        #region Commands
        private RelayCommand _searchCommand;
        public RelayCommand SearchCommand
        { get { return _searchCommand ?? (_searchCommand = new RelayCommand(async () => 
        {
            if (SearchedList.Count > 0)
            {
                if (!string.IsNullOrEmpty(Text))
                {
                    List<Notification> entities = SearchedList.Where(e =>
                     Convert.ToString(e.NotificationSubject).ToLower().Trim().Contains(Text.ToLower().Trim())
                     || Convert.ToString(e.LinkedRecordName).ToLower().Trim().Contains(Text.ToLower().Trim())
                     || Convert.ToString(e.NotificationDateSent).ToLower().Trim().Contains(Text.ToLower().Trim())
                     || Convert.ToString(e.NotificationContent).ToLower().Trim().Contains(Text.ToLower().Trim())).ToList();
                    NotificationsList = new ObservableCollection<Notification>(entities);
                }
                else
                {
                    NotificationsList = SearchedList;
                }
            }
        }
        )); } }
        private string _searchText = string.Empty;
        public string Text          // This is the text property we bind on page   _notificationSearchBar.SetBinding(SearchBar.TextProperty,"TEXT"); 
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    Set(() => Text, ref _searchText, value);
                 
                    if (SearchCommand.CanExecute(null))
                    {
                        SearchCommand.Execute(null);
                       
                    }
                }
            }
        }
        #endregion
        #endregion
