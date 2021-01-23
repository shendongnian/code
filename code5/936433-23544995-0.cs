    public class Person
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    
    	private Institution _Institution;
    	public Institution Institution
    	{
    		get { return _Institution ?? (_Institution = new Institution()); }
    	}
    
    }
    public class Institution
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    
    	private InstitutionType _InstitutionType;
    	public InstitutionType InstitutionType
    	{
    		get { return _InstitutionType ?? (_InstitutionType = new InstitutionType() { Id = 0 }); }
    	}
    
    }
