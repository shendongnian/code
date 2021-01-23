    var busInfo = new Dictionay<string, List<string>>();
    
    
    foreach(var channel in channels)
    {
       busInfo.Add(channel, new List<string>());
       foreach(var label in channel.labels)
       {
          busInfo[channel].Add(label);
       }
    }
