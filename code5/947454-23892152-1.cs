    public class MyViewModel
    {
        public ObservableCollection<CountryDTO> CountryList { get; private set; }
        public MyViewModel(SomeControler refController)
        {
            CountryList = new ObservableCollection(refController.GetCountryData());
        }
    }
