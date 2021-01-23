    public ContactsViewModel(IDataService dataService, INavigationService navigationService)
    {
        _dataService = dataService;
        _navigationService = navigationService;
    }
    private RelayCommand _showConversation;
    public RelayCommand ShowEvents
    {
        get
        {
            return _showConversation ?? (_showConversation = new RelayCommand(ExecuteShowConversation));
        }
    }
    private void ExecuteShowConversation()
    {
        Messenger.Default.Send(new ContactSelectedMessage(){Contact = Contact);
        _navigationService.NavigateTo(new Uri("/Views/ConversationView.xaml", UriKind.RelativeOrAbsolute));
    }
