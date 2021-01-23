    <# if (entity != null && entity.Documentation != null) {#>
    	/// <summary>
    	/// <#= entity.Documentation.Summary #>
    	/// </summary>
    <# } #>
        public <#=code.Escape(entity)#>()
        {
