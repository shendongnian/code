    var item = msStatus.Find(m => m.Value == UserRequest.Status.ToString());
    if(item == null)
    {
        // set selected item to New
        msStatus.Find(m => m.Value == "New").Selected = true; 
    }
    else 
    {
        item.Selected = true;
    }
