    private INotifyCompletion<ObservableCollection<Offer>> _persons;
    public INotifyCompletion<ObservableCollection<Offer>> ModelPersons
    {
      get { return _persons; }
      set
      {
        _persons = value;
        RaisePropertyChanged(() => ModelPersons);
      }
    }
    private void GetPersonOrders()
    {
      ModelPersons = NotifyCompletion.Create(_service.GetPersonOrdersAsync());
    }
