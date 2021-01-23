    public class CommonDropDown
    {
        public string key = "DropDown";
        public List<SelectListItem> myDropDownItems
        {
            get { return HttpContext.Current.Session[key] == null ? GetDropDown() : (List<SelectListItem>)HttpContext.Current.Session[key]; }
            set { HttpContext.Current.Session[key] = value; }
        }
        public List<SelectListItem> GetDropDown()
        {
            // Implement Dropdown Logic here
            // And set like this:
           this.myDropDownItems = DropdownValues;
        }
    }
