    MyList = new SelectList(
      new SelectListItem[] { 
        new SelectListItem {  
          Text = "Select Customer", Value = "", Selected = false 
        } 
      }.Concat(
        myList.GetAll()
          .Select(x => new SelectListItem { Text = x.Customer.Name + " - " + x.Name, Value = x.ID.ToString() })
          .OrderBy(x => x.Text)
    ), "Value", "Text", "0");
