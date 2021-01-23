    IEnumerable<TargetClass> MapOldValues(IEnumerable<SourceClass> source)
    {
        var buffer = new Dictionary<string, string>();
        foreach(var item in source)
        {
            string oldValue;
            buffer.TryGetValue(item.RowId, out oldValue); 
            yield return new TargetClass{ RowId = item.RowId, OldData = oldValue, NewData = item.Data, RowMod = item.RowMod  };
            buffer[item.RowId] = item.Data;
        }
    }
