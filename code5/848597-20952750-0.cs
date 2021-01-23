    var query = session.QueryOver<Message>();
    
    if(finder.MessageId != null) // only in this case we will append the filter
    {
         query.Where(p => p.MessageId == finder.MessageId)
    }
    
    var list = query.List<StreetLight>();
