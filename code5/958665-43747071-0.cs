    public <#=code.Escape(container)#>()
        : this("name=<#=container.Name#>")
	{
	}
	public <#=code.Escape(container)#>(String nameOrConnectionString)
		: base(nameOrConnectionString)
    {
