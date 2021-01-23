     internal class NotificationsPage :  ContentPage
        {
            #region Variables and Controlls declaration 
            private NotificationsViewModel _viewModel; 
            private SearchBar _notificationSearchBar; 
            #endregion Variables and Controlls declaration
    
            #region Constructor
    
            public NotificationsPage()  
            {
                    BindingContext = App.Locator.Notification;
                    _viewModel = BindingContext as NotificationsViewModel;
    
                    _notificationSearchBar = new SearchBar()
                    { 
                    };
                    _notificationSearchBar.SetBinding(SearchBar.TextProperty,"TEXT");
                    _notificationSearchBar.SetBinding(SearchBar.SearchCommandProperty,"SearchCommand" );
            }
     
