    <#@ template language="C#" debug="True" hostspecific="true" #>
    <#@ output extension="js" #>
    <#@ assembly name="System.Core" #>
    <#@ assembly name="EnvDTE" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="EnvDTE" #>
    <#
        var serviceProvider = Host as IServiceProvider;
        if (serviceProvider == null)
        {
            throw new InvalidOperationException("Host is not IServiceProvider");
        }
    
        var dte = serviceProvider.GetService(typeof(DTE)) as DTE;
        if (dte == null)
        {
            throw new InvalidOperationException("Unable to resolve DTE");
        }
    
        var project = dte.Solution.Projects
                                  .OfType<Project>()
                                  .Single(p => p.Name == "ConsoleApplication2");
    
        var model = project.CodeModel
                           .CodeTypeFromFullName("MyApp.LoginModel")
                       as CodeClass;
        //might want to have a list / find all items matching some rule
    
    #>
    var <#= Char.ToLowerInvariant(model.Name[0])
            + model.Name.Remove(0, 1).Replace("Model", "ViewModel") #>= {
    <#
    	foreach (var property in model.Members.OfType<CodeProperty>())
    	{
    		var minLength = property.Attributes
                                        .OfType<CodeAttribute>()
                                        .FirstOrDefault(a => a.Name == "MinLength");
    	    var required = property.Attributes
                                   .OfType<CodeAttribute>()
                                   .FirstOrDefault(a => a.Name == "Required");
    	    var koAttributes = new List<String>();
    	    if (minLength != null)
    	        koAttributes.Add("minLength: " + minLength.Value);
    	    if (required != null)
    	        koAttributes.Add("required: true");
    #>
        <#= property.Name #>: ko.observable().extend({<#=
    String.Join(", ", koAttributes) #>}),
    <#
    	}
    #>
    }
