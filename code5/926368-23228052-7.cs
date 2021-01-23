    var enumerator = _queue.GetMessageEnumerator2();
    var staleDate = DateTime.UtcNow.AddDays(-3); // this removes 3 days from UTC now
    // configure properties to read    
    _queue.MessageReadPropertyFilter.ArrivedTime = true; // false by default
    _queue.MessageReadPropertyFilter.Body = false;       // true by default
    while (enumerator.MoveNext())
    {
         if(enumerator.Current.ArrivedTime.Date >= staleDate)
             enumerator.RemoveCurrent();
    }   
   
