    public void Split(bool shouldTrimQuotes)
    {
         ...
         var value = line.Split('\t');         
         if (shouldTrimQuotes)
         {
             value = value.Select(v => v.Trim(' ', '"'));
         }
         ...
    }
