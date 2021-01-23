    public class TheViewModel{
    	
    	public DeniedIntervalsViewModel[] Intervals{ get; set; }
    }
    
    public class TheController{
    
    	public ActionResult Blah(DeniedIntervalsViewModel[] intervals) {
    	  // ...
    	}
    }
