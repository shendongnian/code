    private List<GaugeItem> outSource;
    public ReadOnlyCollection<GaugeItem> OutSource 
    { 
        get { return new ReadOnlyCollection<GaugeItem>(outSource); } 
    }
