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
    public static class INamespaceSymbolExtension
    {
    	public static IEnumerable<INamedTypeSymbol> GetAllTypes(this INamespaceSymbol @namespace, CancellationToken cancellationToken)
    	{
    		Queue<INamespaceOrTypeSymbol> symbols = new Queue<INamespaceOrTypeSymbol>();
    		symbols.Enqueue(@namespace);
    
    		while (symbols.Count > 0)
    		{
    			cancellationToken.ThrowIfCancellationRequested();
    
    			INamespaceOrTypeSymbol namespaceOrTypeSymbol = symbols.Dequeue();
    			INamespaceSymbol namespaceSymbol = namespaceOrTypeSymbol as INamespaceSymbol;
    			if (namespaceSymbol == null)
    			{
    				INamedTypeSymbol typeSymbol = (INamedTypeSymbol) namespaceOrTypeSymbol;
    				Array.ForEach(typeSymbol.GetTypeMembers().ToArray(), symbols.Enqueue);
    
    				yield return typeSymbol;
    			}
    			else
    			{
    				Array.ForEach(namespaceSymbol.GetMembers().ToArray(), symbols.Enqueue);
    			}
    		}
    	}
    }
