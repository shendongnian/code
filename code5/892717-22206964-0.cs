    if (int.TryParse(userEntry, out entryInt))
    {
        BidMethod(entryInt, MIN);
    }
    else if (double.TryParse(userEntry, out entryDouble))
    {
        BidMethod(entryDouble, MIN);
    }
    else
    {        
        entryString = userEntry.ToLower();
        BidMethod(entryString, MIN);
    }
        
        
        
