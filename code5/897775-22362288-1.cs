    public ConversationViewModel(IDataService dataService, INavigationService navigationService)
    {
        _dataService = dataService;
        _navigationService = navigationService;
        Messenger.Default.Register<ContactSelectedMessage>(this, OnContactSelected);
    }
    private void OnContactSelected(ContactSelectedMessage contactSelectedMessage)
    {
        _dataService.GetConversation(contactSelectedMessage.Contact);
    }
