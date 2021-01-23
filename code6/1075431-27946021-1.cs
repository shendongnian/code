    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        _navigationHelper.OnNavigatedTo(e);
        await _vm.LoadPayees();
    }
    public async Task LoadPayees()
    {
        try
        {
            var json = await FileService.ReadFromFile("folder", "payees.json");
            IList<Payee> payeesFromJson = JsonConvert.DeserializeObject<List<Payee>>(json);
            var payees = new ObservableCollection<Payee>(payeesFromJson);
            _payees = payees;
        }
        catch (Exception)
        {     
            throw;
        }
    
        if (_payees == null)
        {
            _payees = new ObservableCollection<Payee>();
        }
    }
