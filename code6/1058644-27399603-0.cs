    bool IsstatusPresent= msStatus.Any(x=>m.Value == UserRequest.Status.ToString());
    
    if(!IsstatusPresent)
    {
        msStatus.Find(m => m.Value == "New").Selected = true; 
    }
    else 
    {
        item.Selected = true;
    }
