    namespace PSP.ViewModels
    {
        public class ViewModel1 // Choose a more meaningful name for your ViewModel
        {
            public short CountryID { get; set; }
            public IEnumerable<Country> CountriesList { get; set; }
        }
    }
