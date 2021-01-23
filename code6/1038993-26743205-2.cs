    public class PartialModel 
    {
       /// props
    }
    
    public class MainViewModel 
    {
        public PartialModel Partial { get; set; }
        // properties, etc.
        // per comments in other answer you may want something like this
        public MainViewModel()
        {
          Partial = new PartialModel();
        }
    }
