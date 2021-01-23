    var enumerator = _queue.GetMessageEnumerator2();
    var staleDate = DateTime.UtcNow.AddDays(-3); // go figure out, this removes 3 days
    var staleIds = new List<string>();
    
    _queue.MessageReadPropertyFilter.ArrivedTime = true;
    _queue.MessageReadPropertyFilter.Body = false; // don't read the body content for speed
    // configure other props to read
    while (enumerator.MoveNext())
    {
         var msg = msgEnum.Current;
         if(msg.ArrivedTime.Date >= staleDate)
             staleIds.Add(msg.Id)
    }
    
    // take "old" messages by id
    foreach(string id in staleIds)
        _queue.ReceiveById(id);
