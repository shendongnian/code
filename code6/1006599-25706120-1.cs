    // Create collection of anonymous objects (adjust format to suit your needs)
    var receivedCalls = person.ReceivedCalls.Select(c => new 
    {
      ID = c.ID,
      DisplayName = string.Format("{0}: {1:D}", c.Callee.UserName, c.TimeStamp)
    }
    // Initialise view model
    PersonVM model = new PersonVM();
    // Map properties from person to model
    ...
    // Assign select list
    model.CallList  = new MultiSelectList(receivedCalls , "ID", "DisplaName");
    return View(model);
