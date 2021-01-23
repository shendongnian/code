    public IEnumerable<SelectListItem> Genders
    {
        get
        {
            return new[]
            {
                new SelectListItem { Value = "F", Text = "Female" },
                new SelectListItem { Value = "M", Text = "Male" },
            }
        }
    }
