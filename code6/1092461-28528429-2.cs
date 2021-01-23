    public RelayCommand<MyEntity> NavigateDetailsCommand;
    // In your constructor, do this:
    this.NavigateDetailsCommand= new RelayCommand<MyEntity>(navigateDetails);
    // I'm assuming you injected a navigation service into your viewmodel..
    this._navigationService.Configure("itemviewpage", typeof(ItemView));
    
    // Declare a method that does the navigation:
    private void navigateDetails(MyEntity item) {
        this._navigationService.NavigateTo("itemviewpage", item);
    }
