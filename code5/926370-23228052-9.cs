    var enumerator = _queue.GetMessageEnumerator2();  // get enumerator
    var staleDate = DateTime.UtcNow.AddDays(-3);      // take 3 days from UTC now    
    var filter = new MessagePropertyFilter();         // configure props to read
    filter.ClearAll();                                // don't read any property
    filter.ArrivedTime = true;                        // enable arrived time
    _queue.MessageReadPropertyFilter = filter;        // apply filter
    while (enumerator.MoveNext())    
         if(enumerator.Current.ArrivedTime.Date >= staleDate)
             enumerator.RemoveCurrent();
