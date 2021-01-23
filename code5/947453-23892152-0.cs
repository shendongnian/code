    public class MyViewModel
    {
        public string Country { get; set; }
        public List<CountryDTO> CountryList { get; }
        public MyViewModel(SomeControler refController)
        {
            CountryList = refController.GetCountryData();
        }
    }
