    var errorMessages = msgs.Where(...)
                .GroupBy(m => m.StatusCode)
                .Select(g => new 
                     { 
                       StatusCode = g.Key,
                       eSum = db.ErrorSumMessages
                                .FirstOrDefault(
                                m => m.ErrorCode == g.Key 
                                  && m.MessagesId == oldHourlyMessage.MessagesId),
                       Messages = g
                     })
    foreach(var row in errorMessages)
    {
        var eSum = row.eSum;
        var error = row.Messages;
        // rest should work unaltered, except error.Key => row.StatusCode
        ...
        
    }
