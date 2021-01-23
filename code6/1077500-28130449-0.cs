    public static IEnumerable<ICSharpTypeDeclaration> GetAllPublicTypeDeclarations(this IPsiModule module)
    {
    	var declarationCache = module.GetPsiServices().CacheManager.GetDeclarationsCache(module, false, true);
    	var declarations = new List<ICSharpTypeDeclaration>();
    
    	foreach (var shortName in declarationCache.GetAllShortNames())
    	{
    		var declaredElements = declarationCache.GetElementsByShortName(shortName).OfType<ITypeElement>().Where(e => 
    		{
    			var elementType = e.GetElementType();
    			return elementType == CLRDeclaredElementType.CLASS || elementType == CLRDeclaredElementType.INTERFACE || elementType == CLRDeclaredElementType.ENUM;
    		});
    
    		foreach (ITypeElement declaredElement in declaredElements)
    		{
    			var declaration = declaredElement.GetDeclarations().OfType<ICSharpTypeDeclaration>().FirstOrDefault(d => d.GetAccessRights() == AccessRights.PUBLIC);
    			if (declaration != null)
    			{
    				declarations.Add(declaration);
    			}
    		}
    	}
    
    	return declarations;
    }
