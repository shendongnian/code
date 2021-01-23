    @{
       var listItems = new List<SelectListItem>
       {
          new SelectListItem { Text = "USA", Value = "USA" },
          new SelectListItem { Text = "UK", Value = "UK", Selected = true },
          new SelectListItem { Text = "Australia", Value = "AUS" }
       };       
    }
    
    @Html.DropDownListFor(x => x.CountryID, listItems, "-- Select Country --")
