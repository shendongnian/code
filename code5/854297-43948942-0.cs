    /// <summary>
    /// Set this attribute to string property to have nvarchar(max) type for db table column.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class TextAttribute : Attribute
    {
    }
    
    /// <summary>
    /// Changes all string properties without System.ComponentModel.DataAnnotations.StringLength or
    /// Text attributes to use string length 16 (i.e nvarchar(16) instead of nvarchar(max) by default).
    /// Use TextAttribute to a property to have nvarchar(max) data type.
    /// </summary>
    public class StringLength16Convention : Convention
    {
    	public StringLength16Convention()
    	{
    		Properties<string>()
    			.Where(p => !p.GetCustomAttributes(false).OfType<DatabaseGeneratedAttribute>().Any())
    			.Configure(p => p.HasMaxLength(16));
    
    		Properties()
    			.Where(p => p.GetCustomAttributes(false).OfType<TextAttribute>().Any())
    			.Configure(p => p.IsMaxLength());
    	}
    }
    
    public class CoreContext : DbContext, ICoreContext
    {
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		//Change string length default behavior.
    		modelBuilder.Conventions.Add(new StringLength16Convention());
    	}
    }
    
    
    public class LogMessage
    {
    	[Key]
    	public Guid Id { get; set; }
    
    	
    	[StringLength(25)] // Explicit data length. Result data type is nvarchar(25)
    	public string Computer { get; set; }
    	
    	//[StringLength(25)] // Implicit data length. Result data type is nvarchar(16)
    	public string AgencyName { get; set; }
    	
    	[Text] // Explicit max data length. Result data type is nvarchar(max)
    	public string Message { get; set; }
    }
