    public RelayCommand<object> GiveDetails { get; private set; }
    public HspitalVM()
        {
            hspitalList=ReadToObject();
            GiveDetails = new RelayCommand<object>(DoSomething);
        }
     private void DoSomething(object param)
        {
            var fetchedCountry = (Hspital)param;
            
            MessageBox.Show("The country name is " + fetchedCountry.Name);
        }
