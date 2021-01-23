    // Create a list from the result of GetStates
    var states = svc.GetStates(user.Login, user.Password).ToList();
    // Add whatever you like
    states.Add(...);
    // Create the SelectList
    m.StateList = new SelectList(states, "Key", "Value");
