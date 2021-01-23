    public void Split(bool shouldTrimQuotes)
    {
         ...
         IEnumerable<string> value = line.Split('\t');         
         if (shouldTrimQuotes)
         {
             value = value.Select(v => v.Trim(' ', '"'));
         }
         ...
    }
