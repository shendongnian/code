    public MainPage()
    {
        var data = new List<DublinBelfast> 
        { 
            new DublinBelfast("Dublin (Busáras)", "01:00 (Departure)"),
            new DublinBelfast("Dublin Airport (Atrium Road, Zone 10)","01:20 (P)"),
            new DublinBelfast("Newry (Buscentre)","02:30 (D)"),
            new DublinBelfast("Banbridge (Kenlis Street)","02:50 (D)"),
            new DublinBelfast("Sprucefield (Shopping Centre)","03:10 (D)"),
            new DublinBelfast("Belfast (Europa Bus Centre)","03:25 (Arrival)")
        };
    
        ic.ItemsSource = data;
    }
    
    
    public class DublinBelfast
    {
        public string stops { get; set; }
        public string times { get; set; }
    
        public DublinBelfast(string Stops, string Times)
        {
            stops = Stops;
            times = Times;
        }
    }
