    public class YourViewModel
    {
        // This could be string, int or Guid depending on what you need as the value
        public int YourDropdownSelectedValue { get; set; }
        public IEnumerable<SelectListItem> YourDropdownList { get; set; }
    }
    
