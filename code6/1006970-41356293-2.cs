    private ObservableCollection<Notification> _notificationsList;
    
            public ObservableCollection<Notification> NotificationsList
            {
                get { return _notificationsList; }
                set
                {
                    Set(() => NotificationsList, ref _notificationsList, value);
                }
            }
    
    
    
            /// <summary>
            /// Holds Searched notifications
            /// </summary>
            private ObservableCollection<Notification> _searchedList;
    
            public ObservableCollection<Notification> SearchedList
            {
                get { return _searchedList; }
                set
                {
                    Set(() => SearchedList, ref _searchedList, value);
                }
            }
