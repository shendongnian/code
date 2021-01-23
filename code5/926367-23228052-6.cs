    var enumerator = _queue.GetMessageEnumerator2();
    var staleDate = DateTime.UtcNow.AddDays(-3); // go figure out, this removes 3 days
    
    _queue.MessageReadPropertyFilter.ArrivedTime = true;
    _queue.MessageReadPropertyFilter.Body = false; // don't read the body content for speed
    // configure other props to read
    while (enumerator.MoveNext())
    {
         if(enumerator.Current.ArrivedTime.Date >= staleDate)
             enumerator.RemoveCurrent();
    }   
   
