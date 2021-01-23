    var items = myList
      .GetAll()
      .Select(
        x => new SelectListItem {
          Text = x.Customer.Name + " - " + x.Name,
          Value = x.ID.ToString()
        }
      )
      .OrderBy(x => x.Text);
 
    var itemsWithInitialItem = new SelectListItem[] {
        new SelectListItem {  
          Text = "Select Customer", Value = "", Selected = false 
        } 
      }
      .Concat(items);
    MyList = new SelectList(itemsWithInitialItem, "Value", "Text", "0");
