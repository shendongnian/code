    public class FooViewModel
    {
        public FooViewModel()
        {
            SelectedCountryIds = new List<int>();
        }
        ...
        public List<int> SelectedCountryIds { get; set; }
        public IEnumerable<SelectListItem> CountryChoices { get; set; }
    }
