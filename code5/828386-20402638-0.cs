    private Dictionary<String, GaugeItem> outSource;
    public ReadOnlyDictionary<string, GaugeItem> OutSource 
    { 
        get { return new ReadOnlyDictionary<string, GaugeItem>(outSource); } 
    }
