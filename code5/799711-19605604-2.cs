    public static class CompilationExtensions
    {
    	public static INamedTypeSymbol FindSymbol(this CommonCompilation compilation, Type searchedType)
    	{
    		var splitFullName = searchedType.FullName.Split('.');
    		var namespaceNames = splitFullName.Take(splitFullName.Length - 1).ToArray();
    		var className = splitFullName.Last();
    
    		if (namespaceNames.Length == 0)
    			return compilation.GlobalNamespace.GetAllTypes(new CancellationToken()).First(n => n.Name == className);
    
    		var namespaces = compilation.GlobalNamespace.GetNamespaceMembers();
    		INamespaceSymbol namespaceContainingType = null;
    		foreach (var name in namespaceNames)
    		{
    			namespaceContainingType = namespaces.First(n => n.Name == name);
    			namespaces = namespaceContainingType.GetNamespaceMembers();
    		}
    
    		return namespaceContainingType.GetAllTypes(new CancellationToken()).First(n => n.Name == className);
    	}
    }
