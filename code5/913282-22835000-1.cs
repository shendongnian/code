    public IEnumerable<SelectListItem> GetList(string selectedValue)
    {
        return new SelectListItem[] {
            new SelectListItem { Value = "1", Text = "One", Selected = (selectedValue == "1") },
            new SelectListItem { Value = "2", Text = "Two", Selected = (selectedValue == "2") },
            new SelectListItem { Value = "3", Text = "Three", Selected = (selectedValue == "3") }
        };
    }
