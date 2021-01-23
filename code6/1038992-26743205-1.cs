    public class PartialModel 
    {
       /// props
    }
    
    public class MainViewModel 
    {
        public ParitalModel partial { get; set; }
        // properties, etc.
        // per comments in other answer you may want something like this
        public MainViewModel()
        {
          partial = new PartialModel();
        }
    }
