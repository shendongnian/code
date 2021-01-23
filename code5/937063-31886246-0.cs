    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ include file="AssemblyReferences.tt" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="ICSharpCode.NRefactory.CSharp" #>
    <#@ output extension=".cs"#>
    <# 
    var file = System.IO.File.ReadAllText(this.Host.ResolvePath("IUserService.cs")); 
    if(!file.Contains("using System.Threading.Tasks;"))
    { #>
    using System.Threading.Tasks;
    <# } #>
    <#
    CSharpParser parser = new CSharpParser();
    var syntaxTree = parser.Parse(file);
    
    
    foreach (var namespaceDeclaration in syntaxTree.Descendants.OfType<NamespaceDeclaration>())
    {
        namespaceDeclaration.Name += ".Client";
    }
                
    
    foreach (var methodDeclaration in syntaxTree.Descendants.OfType<MethodDeclaration>())
    {
        if (methodDeclaration.Name.Contains("Async"))
            continue;
    
        MethodDeclaration asyncMethod = methodDeclaration.Clone() as MethodDeclaration;
        asyncMethod.Name += "Async"; 
    
        if (asyncMethod.ReturnType.ToString() == "void")
            asyncMethod.ReturnType = new SimpleType("Task");
        else
            asyncMethod.ReturnType = new SimpleType("Task", typeArguments: asyncMethod.ReturnType.Clone());
                    
        methodDeclaration.Parent.AddChild(asyncMethod, Roles.TypeMemberRole);
    }
    
    #>
    <#=syntaxTree.ToString()#>​
