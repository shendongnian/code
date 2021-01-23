    int rowNumber = ...
    int columnNumber = ...
    IEnumerable<object> values = ...
    
    var range = ws.Cells[rowNumber, columnNumber];
    range.LoadFromArrays(AsEnumerable(values.ToArray())); 
 
    /* ... */
    // see http://stackoverflow.com/q/1577822/614800 for a discussion on how
    // to wrap an object into an IEnumerable
    private static IEnumerable<T> AsEnumerable<T>(T obj)
    {
        yield return obj;
    }
