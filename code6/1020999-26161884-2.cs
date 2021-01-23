    void Main() {
    	XmlSerializer ser = new XmlSerializer(typeof(KpiPath));
    	KpiPath newPath = new KpiPath();
    	
    	newPath.Kpis.Add(new KPI() {Name = "test", RequestTemplateFullPath = @"C:\test", RequestFullPath = @"C:\test"});
    	newPath.Kpis.Add(new KPI() {Name = "test", RequestTemplateFullPath = @"C:\newTest", RequestFullPath = @"C:\newTest"});
    	newPath.Kpis.Add(new KPI() {Name = "anotherTest", RequestTemplateFullPath = @"C:\funTest", RequestFullPath = @"C:\funTest"});
    	StringBuilder sb = new StringBuilder();
    	using(StringWriter writer = new StringWriter(sb)) {
    		ser.Serialize(writer, newPath);
    	} // end using
    	Debug.WriteLine(sb.ToString());
    	
    	List<KPI> matches = newPath.KPIFromName("test");
    	
    	//For debugging, make sure we get two results (matching the two named test above), print a failure message if not.
    	Debug.Assert(matches.Count == 2, "Invalid Count");
    	
    }
    
    [XmlRoot("KPIPATHS"), Serializable()]
    public sealed class KpiPath {
    
    	[XmlArray("KPIS")]
    	public List<KPI> Kpis { get; set; }
    
    	public KpiPath() {
    		Kpis = new List<KPI>();
    	} // end default constructor
    	
    	public List<KPI> KPIFromName(string kpiName) {
    		if(String.IsNullOrWhiteSpace(kpiName)) {
    			throw new ArgumentNullException("kpiName", "No name provided.");
    		} // end if
    		List<KPI> matches = new List<KPI>();
    		if(this.Kpis.Any()) {
    			for(int i = 0; i < this.Kpis.Count; i++) {
    				if(this.Kpis[i].Name.ToUpperInvariant() == kpiName.ToUpperInvariant()) {
    					matches.Add(this.Kpis[i]);
    				} // end if
    			} // end for loop
    		} // end if
    		
    		return matches;
    	} // end function GetFromName
    	
    } // end class KpiPath
    
    [Serializable()]
    public sealed class KPI {
    
    	[XmlElement("Name")]
    	public string Name { get; set; }
    	[XmlElement("RequestTemplateFullPath")]
    	public string RequestTemplateFullPath { get; set; }
    	[XmlElement("RequestFullPath")]
    	public string RequestFullPath { get; set; }
    
    	public KPI() {
        } // end default constructor
    	
    } // end class KPI
