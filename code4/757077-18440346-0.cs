    public ICommand CloseCommand
        {
            get
            {
                return new RelayCommand(OnClose, IsEnable);
            }
        }
    public void OnClose(object param)
        {
           AddClientView/SuggestedAddressesView Obj = param as AddClientView/SuggestedAddressesView;
           obj.Close();
        }
