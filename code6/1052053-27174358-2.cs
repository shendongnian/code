    public class CountryList
    {
        // this may have to be a List<SelectListItems> to work with MultiSelectList - check.
        public SelectList Countries{ get; set; }
        public List<int> SelectedCountryIds { get; set; }
    }
