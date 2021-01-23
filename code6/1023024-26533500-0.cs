    // Single related item
    var sfEvent = sfContent.GetOriginal().GetRelatedItems<Event>("Event").FirstOrDefault();
    if (sfEvent != null)
    {
        Event = new EventModel(sfEvent);
    }
    
    // List of related items
    Sessions = sfContent.GetOriginal().GetRelatedItems<DynamicContent>("Sessions")
        .Select(x => new SessionModel(x))
        .ToList();
