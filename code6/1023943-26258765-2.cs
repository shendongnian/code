    var existing = LogSummary.FirstOrDefault(t=>t.Item1 == _stringFromEvent)
    if(existing != null)
    {
         //update
          LogSummary[LogSummary.IndexOf(existing)] = 
                         new Tuple<string, int>(existing.Item1, intValue);
    }
    else
    {
        //insert new
    }
