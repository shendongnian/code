    public class LineData
    {
        public int LineIndex { get; set; }
    
        public string LocationCode { get; set; }
    
        // other data from the line that you need
    }
    
    // ...
    
    private Dictionary<long, LineData> _dataMap = new Dictionary<long, LineData> ();
    
    // ...
    // Read file, parse lines into LineData objects and put them in dictionary
    // ...
    // to see if a record ID exists, you just call TryGetValue
    LineData lineData;
    if ( _dataMap.TryGetValue ( recordID, out lineData ) )
    {
        // record ID was found
    }
