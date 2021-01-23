    bool IsstatusPresent= msStatus.Any(x=>m.Value == UserRequest.Status.ToString());
    
    if(!IsstatusPresent)
    {
       return msStatus.Find(m => m.Value == "New").Selected;
    }
    else 
    {
       return  msStatus.Find(x=>m.Value == UserRequest.Status.ToString());
    }
