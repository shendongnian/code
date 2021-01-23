    void Main()
    {
    	// Initialize the overall system, but don't count the result.
    	BuildC();
    
    	DateTime startDateA = DateTime.Now;
    	BuildA();
    	DateTime.Now.Subtract(startDateA).TotalMilliseconds.Dump("A");
    	
    	DateTime startDateB = DateTime.Now;
    	BuildB();
    	DateTime.Now.Subtract(startDateB).TotalMilliseconds.Dump("B");
    }
    
    public class PersonA
    {
    	public int PersonAId { get; set; }
    	public string Name { get; set; }
    }
    
    private void BuildA()
    {
    	var builder = new DbModelBuilder();
    	builder.Entity<PersonA>();
    	var model = builder.Build(new DbProviderInfo("System.Data.SqlClient", "2008"));
    	model.Compile();
    }
    
    public class PersonB
    {
    	public int PersonBId { get; set; }
    	public string Name { get; set; }
    }
    
    private void BuildB()
    {
    	var builder = new DbModelBuilder();
    	builder.Conventions.Remove<IdKeyDiscoveryConvention>();
    	builder.Entity<PersonB>()
    		.HasKey(p => p.PersonBId);
    	var model = builder.Build(new DbProviderInfo("System.Data.SqlClient", "2008"));
    	model.Compile();
    }
    
    public class PersonC
    {
    	public int PersonCId { get; set; }
    	public string Name { get; set; }
    }
    
    private void BuildC()
    {
    	var builder = new DbModelBuilder();
    	builder.Entity<PersonC>()
    		.HasKey(p => p.PersonCId);
    	var model = builder.Build(new DbProviderInfo("System.Data.SqlClient", "2008"));
    	model.Compile();
    }
