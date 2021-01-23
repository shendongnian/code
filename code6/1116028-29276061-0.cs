            ViewBag.Type = new SelectList()
                  { 
                      new SelectListItem(){ Value="1", Text="a" },
                      new SelectListItem(){ Value="2", Text="b" }, 
                      new SelectListItem(){ Value="3", Text="c", Selected = true }
                  }
    
        ///----in your view
         @Html.DropDownListFor(m => m.Type, ViewBag.Type as SelectList, "Select type")
