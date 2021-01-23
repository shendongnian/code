    <# if (code.Escape(container) != null) {#>
    /// <summary>
    /// Represents <#= code.Escape(container) #>
    /// </summary>
    <# } #>
    <#=Accessibility.ForType(container)#> partial class <#=code.Escape(container)#> : DbContext
    {
    
    <# if (code.Escape(container) != null) {#>
    	/// <summary>
    	/// Initializes a new instance of the <see cref="<#= code.Escape(container) #>"/> class.
    	/// </summary>
    <# } #>
    	public <#=code.Escape(container)#>()
        : base("name=<#=container.Name#>")
        {
    <#
    if (!loader.IsLazyLoadingEnabled(container))
    {
    #>
            this.Configuration.LazyLoadingEnabled = false;
    <#
    }
    #>
        }
    	
    	/// <summary>
    	/// On Model Creating
    	/// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    <#
        foreach (var entitySet in container.BaseEntitySets.OfType<EntitySet>())
        {
    #>
    
       <# if (code.Escape(entitySet) != null) {#>
    	/// <summary>
    	/// Gets or sets the <#=code.Escape(entitySet)#>
    	/// </summary>
    	<# } #>
