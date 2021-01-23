    if (ModelState.IsValid)
    {
      ....
      // assumes your using a view model named ChildVM and property Childs is typeof List<ChildVM>
      foreach(ChildVM item in viewmodel.Childs) 
      {
        // Create a new Child based on ChildVM
        var child = new Child()
        {
          Name = item.Name,
          DOB = item.DOB,
          Address = item.Address
        };
        db.Childs.Add(child);
      }
      ....
      db.SaveChanges();
    }
    
 
