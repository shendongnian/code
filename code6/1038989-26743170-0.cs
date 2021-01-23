    public class FullList {
        public int ID              { get; set; }
        public string Event        { get; set; }
    	public string Text         { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd   { get; set; }
        public string  Days        { get; set; }
        public int Repeat          { get; set; }
    	public string Room         { get; set; }
    	public DateTime StartDate  { get; set; }
    	
    	public override string ToString() {
    		return ID + "#" + Text + "#" + EventStart + "#" + EventEnd + "#" + Repeat+ "#" + Days + "#" + Room + "#" + StartDate);
    	}
    }
    
    public class FullListCollection : List<FullList> {
    
    	public List<FullList> FindByStartEnd (DateTime start, DateTime end) {
            FullListCollection events = new FullListCollection();
    		events.AddRange(this.Find(x => x.EventStart >= start && x.EventEnd <= end));
            return events;
    	}
    }
    
    // in the client class, assume we have a populated FullListCollection
    myEventList // our list of events
    FullListCollection EventsInDateRange = myEventList.FindByStartEnd ( <somestartdate>, <someenddate>);
