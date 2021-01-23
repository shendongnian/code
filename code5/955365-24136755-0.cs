    var items = new SelectListItem[] {
        new SelectListItem {  
          Text = "Select Customer", Value = "", Selected = false 
        } 
      }
      .Concat(
        myList
          .GetAll()
          .Select(
            x => new SelectListItem {
              Text = x.Customer.Name + " - " + x.Name,
              Value = x.ID.ToString()
            }
          )
      )
      .OrderBy(x => x.Text);
    MyList = new SelectList(items, "Value", "Text", "0");
