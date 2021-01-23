    var enumerator = _queue.GetMessageEnumerator2();
    var staleDate = DateTime.UtcNow.AddDays(-3);
    var staleIds = new List<string>();
    
    _queue.MessageReadPropertyFilter.ArrivedTime = true;
    _queue.MessageReadPropertyFilter.Body = false; // don't read the content
    while (enumerator.MoveNext())
    {
         var msg = msgEnum.Current;
         if(msg.ArrivedTime.Date >= staleDate)
             staleIds.Add(msg.Id)
    }
    
    foreach(string id in staleIds)
        _queue.ReceiveById(id);
