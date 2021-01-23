    <#@ template debug="true" hostSpecific="true" #>
    <#@ output extension=".js" #>
    <#@ Assembly Name="System.Core" #>
    <#@ Assembly Name="System.Windows.Forms" #>
    <#@ import namespace="System" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Diagnostics" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Collections" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="EnvDTE" #>
    <#@ include file="..\T4\Automation.ttinclude"#>
    (function() {
    	function ensureClosure(root, namespace) {
    		if(typeof namespace === "string") {
    			namespace = namespace.split(".");
    		}
    		if (namespace.length == 0) {
    			return;
    		}
    
    		var part = namespace[0];
    		namespace.splice(0, 1);
    		root[part] = root[part] || {};
    
    		ensureClosure(root[part], namespace);
        }
    
    <# 
    
    var project = VisualStudioHelper.GetProject("MyApp.Core.Contracts");		
    
    var contracts = GetSubClasses("MyApp.Core.Contracts.Commands.Command", project)
    	.Concat(GetSubClasses("MyApp.Core.Contracts.Queries.Query", project));
    var nameSpaces = contracts.GroupBy(c => c.Namespace.Name);
    
    foreach(var @namespace in nameSpaces)
    {
    	#>	ensureClosure(window, "<#=@namespace.Key#>");
    <# 
    }
    
    foreach(var contract in contracts) {
    	var properties = GetProperties(contract).Select(p => CamelCased(p.Name)).ToList();
    	var args = string.Join(", ", properties);
    
    	#>
    
    	<#= contract.FullName #> = function(<#= args #>) {<#
    	foreach(var property in properties) {#>
    
    		this.<#= property #> = <#= property #>;<#
    	}#>
    
    	};
    <#
    }
    #>
    })();
    
    <#+
    
    public IEnumerable<CodeClass> GetSubClasses(string baseClass, Project project)
    {
    	return VisualStudioHelper		
    		.CodeModel
    		.GetAllCodeElementsOfType(project.CodeModel.CodeElements, EnvDTE.vsCMElement.vsCMElementClass, false)
    		.Cast<CodeClass>()
    		.Where(c => GetInheritance(c).Any(b => b.FullName == baseClass))
    		.ToList(); 
    }
    
    
    public IEnumerable<CodeClass> GetInheritance(CodeClass @class) 
    {
    	return GetInheritance(@class, new List<CodeClass>());
    }
    
    public IEnumerable<CodeClass> GetInheritance(CodeClass @class, List<CodeClass> collection) 
    {
    	foreach(CodeClass @base in @class.Bases) 
    	{
    		collection.Add(@base);
    		GetInheritance(@base, collection);
    	}
    
    	return collection;
    }
    
    public string CamelCased(string pascalCased) {
    	return pascalCased.Substring(0, 1).ToLower() + pascalCased.Substring(1);
    }
    
    public IEnumerable<CodeProperty> GetProperties(CodeClass @class)
    {
    	return @class
    		.Members
    		.Cast<CodeElement>()
    		.Where(ce => ce.Kind == vsCMElement.vsCMElementProperty)
    		.Cast<CodeProperty>()
    		.Where(p => p.Access == vsCMAccess.vsCMAccessPublic);	
    }
    
     #>
