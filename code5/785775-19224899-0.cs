    void Main()
    {
    String[] PREFERED = new String[] { "37", "22", "18" };
    List<Stream> library =  new  List<Stream> () ;
    library.Add (new Stream () {ID ="22" }) ;
    library.Add (new Stream () {ID ="37" }) ;
    library.Add (new Stream () {ID ="18" }) ;
    library.Dump () ;
    library.OrderBy(o => Array.IndexOf(PREFERED, o.ID)).ToList().Dump () ;
    	
    }
    
    public class Stream
    {
    	public String ID { get; set; }
        public String URL { get; set; }
        public String Description { get; set; }
        public String Type { get; set; }
    }
