    public ICommand LoginCommand
    {
        get
        {
            return new RelayCommand(async () => await Login());
        }
    }
    public async Task Login()
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        Customer c = new Customer();
        c = await GetCustomerFromIDReader();
        if(c == null)
        {
            Console.Write("Er is iets fout gelopen bij het inlezen van de e-IDkaart");
        }
        else if (ApplicationVM.customer == null)
        {
            appvm.ChangePage(typeof(KlantNieuwVM));
        }
        else
        {
            appvm.ChangePage(typeof(KlantenInterfaceVM));
        }
    }
