    public IEnumerable<SelectListItem> Priorities { get; set; }
    Priorities = new List<SelectListItem>();
    
    Priorities = Priorities.Concat(new List<SelectListItem>() {
                    new SelectListItem { Text = "High", Value = "1"},
                    new SelectListItem { Text = "Low", Value = "0"}
                    }
            );
