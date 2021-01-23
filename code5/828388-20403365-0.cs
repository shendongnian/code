    public class THRManager
    {
       private List<GaugeItem> outsource;
       private ReadOnlyCollection<GaugeItem> outSourceReadOnly;
    
        public THRManager()
        {
            outSource = new List<GaugeItem>();
            outSourceReadOnly = new ReadOnlyCollection<GaugeItem>(outSource);
        }
    
        public ReadOnlyCollection<GaugeItem> OutSource 
        { 
            get { return outSourceReadOnly; } 
        }
    }
