    Dictionary<Button,string> lastNameFilterByButton = new Dictionary<Button,string>()`
    mapping.Add(LinkButtonA, "A");
    mapping.Add(LinkButtonB, "B");
    mapping.Add(LinkButtonC, "C");
    mapping.Add(LinkButtonD, "D");
    // ...    
    Session["LastNameFilter"] = lastNameFilterByButton[sender]
