    // Get database values (by whatever selection method is appropriate)
    var dbValues = db.YourEntity.ToList();
        
    // Make Selectlist, which is IEnumerable<SelectListItem>
    var yourDropdownList = new SelectList(dbValues.Select(item => new SelectListItem
    {
        Text = item.YourSelectedDbText,
        Value = item.YourSelectedDbValue
    }).ToList(), "Value", "Text");
    
    // Assign the Selectlist to the View Model   
    var viewModel = new YourViewModel(){
        // Optional: if you want a pre-selected value - remove this for no pre-selected value
        YourDropdownSelectedValue = dbValues.FirstOrDefault(),
        // The Dropdownlist values
        YourDropdownList = yourDropdownList
    };
    
    // return View with View Model
    return View(viewModel);
    
