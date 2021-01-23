    IEnumerable<TargetClass> MapOldValues(IEnumerable<SourceClass> source)
    {
        var buffer = new Dictionary<string, string>();
        foreach(var item in source)
        {
            string oldValue;
            buffer.TryGetValue(item.RowId, out oldValue); 
            yield return new TargetClass
                              {
                                  RowId = item.RowId, 
                                  OldData = oldValue, 
                                  NewData = (item.RowMod == "D" ? null : item.Data), 
                                  RowMod = item.RowMod  };
            // if the rows come sorted by ID, you can clear old values from
            // the buffer to save memory at this point:
            // if(oldValue == null) { buffer.Clear(); }
            buffer[item.RowId] = item.Data;
        }
    }
