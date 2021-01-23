        private RelayCommand _NewCountryCommand; // you can find the RelayCommand Class on the web
        public ICommand NewCountryCommand
        {
            get { return _NewCountryCommand ?? (_NewCountryCommand= new RelayCommand(param => this.OnNewCountry())); }
        }
        public void OnNewCountry()
        {
             var window = new Window(); // or whatever View you use
             var vm = new NewCountryClass();
             window.DataContext= vm;
             window.ShowDialog();
             if(vm.Result)// Result will be set to true 
                          // if the user Click the Save Button in your CountryV
             {
                  // here will be your logic if the user want to save his stuff
                  // in my case
                  CountryCollection.Add(vm)
                  SelectedCountryItem = vm;
             }
        }
    public ObservableCollection<NewCountryClass> CountryCollection
    {
        get { return collections; }
        set { collections = value; 
              OnPropertyChanged(() => CountryCollection); }
    }
    
    public NewCountryClass SelectedCountryItem
    {
        get { return selectedCountryItem; //}
        set { selectedCountryItem = value; 
              OnPropertyChanged(() => SelectedCountryItem); }
    }
