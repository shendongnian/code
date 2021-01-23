    DateList.IsBatchModeActive = true;  // Disables collection change events
    DateList.Clear();
    
    foreach (DateItem item in parsemonth.GetNextMonth())
        DateList.Add(item);
    
    DateList.IsBatchModeActive = false;  // Sends a collection changed event of Reset and re-enables collection changed events
