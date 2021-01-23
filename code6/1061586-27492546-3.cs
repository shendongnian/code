    public class LineData
    {
        public int LineIndex { get; set; }
    
        public string LocationCode { get; set; }
    
        // other data from the line that you need
    }
    
    // ...
    
    // declare your map
    private Dictionary<long, LineData> _dataMap = new Dictionary<long, LineData> ();
    
    // ...
    // Read file, parse lines into LineData objects and put them in dictionary
    // ...
