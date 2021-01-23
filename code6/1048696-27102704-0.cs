    private ICommand _onOrderSearchClickCommand;
    public ICommand OnOrderSearchClickCommand
    {
        get
        {
            if (_onOrderSearchClickCommand != null) return _onOrderSearchClickCommand;
                _onOrderSearchClickCommand = new RelayCommand(OrderSearchButtonClick);
            return _onOrderSearchClickCommand;
        }
    }
    public void OrderSearchClick(object sender)
    {
        IsSearchBarVisible = Visibility.Visible;
        Console.WriteLine(isSearchBarVisible);
        int orderID;
        if(Int32.TryParse(param.ToString(), out orderID))
            ShowMainOrderDetails(orderID);
    }
