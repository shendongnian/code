    private async void DoAndScroll()
    {
       await App.MessagesViewModel.LoadData();
       var lastMessage = App.MessagesViewModel.Messages.LastOrDefault();
       llsMessages.ScrollTo(lastMessage);
    }
    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
       string contactId = "";
       if (NavigationContext.QueryString.TryGetValue("contactId", out contactId))
       {
          DataContext = App.MessagesViewModel;  
          DoAndScroll();     
       }
    }
