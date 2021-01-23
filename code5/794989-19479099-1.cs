    public ViewModel(ref SharedViewModel sharedViewModel)
    {
      sharedvm=sharedViewModel;
      sharedvm.Collection.Add(new object());
    }
