    <#@ SqlModelDirective processor="SqlModelDirectiveProcessor" #>
    <#@ import namespace="Microsoft.SqlServer.Dac.Model" #>
    <#@ assembly name="Microsoft.SqlServer.Dac.Extensions" #>
    <#@ include file="..\Helper.tt" #>
    <#
    blyablyablya
    
    var allTables = GetAllTables();
    
    blyablyablya
    #>
    <#+
        // Example method.
    	public List<TSqlObject> GetAllTables()
    	{
    		List<TSqlObject> allTables = new List<TSqlObject>();
        
    		var model = GetModel();
    		if (model == null) 
    			return allTables;
    
    		var tables = model.GetObjects(DacQueryScopes.All, ModelSchema.Table);
    		if (tables != null)
    		{
    			allTables.AddRange(tables);
    		}
    		return allTables;
    	}
    #>
