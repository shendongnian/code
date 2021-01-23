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
    <#@ include file="..\T4\Automation.ttinclude"#><#
    var project = VisualStudioHelper.GetProject("MyApp.Core.Contracts");      
    var contracts = GetSubClasses("MyApp.Core.Contracts.Commands.Command", project)
    	.Concat(GetSubClasses("MyApp.Core.Contracts.Queries.Query", project));
    
    #>(function(MyApp) {
    	function buildContract(contract) {
    		return { type: contract.constructor.type, data: ko.toJSON(contract) };
    	}
    	var url = "api/commandQuery";
    	MyApp.cqrs = {
    		sendQuery: function(query, callback) {
    			$.getJSON(url, buildContract(query), callback);
    		},
    		sendCommand: function(command) {
    			MyApp.utils.post(url, buildContract(command));
    		}
    	};
    <#
    
    
    foreach(var contract in contracts) {
    		#>	
    	<#
    	foreach(var part in BuildNameSpace(contract)) {
    		#><#= part #>
    	<#
    	}
    
        var properties = GetProperties(contract).Select(p => CamelCased(p.Name)).ToList();
        var args = string.Join(", ", properties);
    
        #>
    
        window.<#= contract.FullName #> = function(<#= args #>) {<#
        foreach(var property in properties) {#>
    
            this.<#= property #> = <#= property #>;<#
        }
    	#>
    
        };
    	window.<#= contract.FullName #>.type = "<#= contract.FullName #>";
    <#
    }
    #>
    })(window.MyApp = window.MyApp || {});
    <#+
    
    private static IEnumerable<string> BuildNameSpace(CodeClass @class)
    {
        return BuildNameSpace(@class.Namespace.Name.Split('.'), "window", new List<string>());
    }            
    
    private static IEnumerable<string> BuildNameSpace(IEnumerable<string> @namespace, string parent, List<string> parts)
    {
        var part = @namespace.FirstOrDefault();
        if (part == null) return parts;
    
        var current = string.Format("{0}.{1}", parent, part);
        parts.Add(string.Format("{0} = ({0} || {{}});", current));
        return BuildNameSpace(@namespace.Skip(1), current, parts);
    }
    
    public IEnumerable<CodeClass> GetSubClasses(string baseClass, Project project)
    {
    	return VisualStudioHelper		
    		.CodeModel
    		.GetAllCodeElementsOfType(project.CodeModel.CodeElements, EnvDTE.vsCMElement.vsCMElementClass, false)
    		.Cast<CodeClass>()
    		.Where(c => GetInheritance(c).Any(b => b.FullName == baseClass) && !c.IsAbstract)
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
    	if (@class == null) 
    		return new List<CodeProperty>();
    
    	var baseProperties = GetProperties(@class.Bases.Cast<CodeClass>().FirstOrDefault());
    
    	return baseProperties.Concat(@class
    		.Members
    		.Cast<CodeElement>()
    		.Where(ce => ce.Kind == vsCMElement.vsCMElementProperty)
    		.Cast<CodeProperty>()
    		.Where(p => p.Access == vsCMAccess.vsCMAccessPublic));
    	}
     #>
