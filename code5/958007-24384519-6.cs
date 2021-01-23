    // </auto-generated code>
    public partial class TestingEntities : DbContext
    {
    	public TestingEntities()
    		: base("name=TestingEntities")
    	{
    	}
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		throw new UnintentionalCodeFirstException();
    	}
    
    	public DbSet<XMLTest> XMLTests { get; set; }
    
    	[EdmFunction("TestingEntities", "FilterCustomersByRating")]
    	public virtual IQueryable<FilterCustomersByRating_Result> FilterCustomersByRating(Nullable<int> rating)
    	{
    		var ratingParameter = rating.HasValue ?
    			new ObjectParameter("Rating", rating) :
    			new ObjectParameter("Rating", typeof(int));
    
    		return ((IObjectContextAdapter)this)
			.ObjectContext
			.CreateQuery<FilterCustomersByRating_Result>("[TestingEntities]
				.[FilterCustomersByRating](@Rating)", ratingParameter);
    	}
    }
