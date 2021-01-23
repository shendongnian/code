    var enumerator = _queue.GetMessageEnumerator2();
    var staleDate = DateTime.UtcNow.AddDays(-3);
    var staleIds = new List<string>();
    
    while (enumerator.MoveNext())
    {
         var msg = msgEnum.Current;
         // there is possibly a cleaner way to do this, depends on what you call "stale"
         if((YOUR_TYPE)msg.Body).YOUR_SEND_DATE_PROPERTY < staleDate)
             staleIds.Add(msg.Id)
    }
    
    foreach(string id in staleIds)
        _queue.ReceiveById(id);
