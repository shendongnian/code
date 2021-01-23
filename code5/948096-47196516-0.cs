    private IEnumerable<MetadataReference> GetGlobalReferences()
    {
        var assemblies = new [] 
            {
    			/*Making sure all MEF assemblies are loaded*/
    			typeof(System.Composition.Convention.AttributedModelProvider).Assembly,	//System.Composition.AttributeModel
    			typeof(System.Composition.Convention.ConventionBuilder).Assembly,	//System.Composition.Convention
    			typeof(System.Composition.Hosting.CompositionHost).Assembly,		//System.Composition.Hosting
    			typeof(System.Composition.CompositionContext).Assembly,				//System.Composition.Runtime
    			typeof(System.Composition.CompositionContextExtensions).Assembly,	//System.Composition.TypedParts
    					
    			/*Used for the GeneratedCode attribute*/
    			typeof(System.CodeDom.Compiler.CodeCompiler).Assembly,				//System.CodeDom.Compiler
            };
    
    	var refs = from a in assemblies	
                    select new MetadataFileReference(a.Location);
    	var returnList = refs.ToList();
    
    	//The location of the .NET assemblies
    	var assemblyPath = Path.GetDirectoryName(typeof(object).Assembly.Location);
    
    	/* 
    		* Adding some necessary .NET assemblies
    		* These assemblies couldn't be loaded correctly via the same construction as above,
    		* in specific the System.Runtime.
    		*/
    	returnList.Add(new MetadataFileReference(Path.Combine(assemblyPath, "mscorlib.dll")));
    	returnList.Add(new MetadataFileReference(Path.Combine(assemblyPath, "System.dll")));
    	returnList.Add(new MetadataFileReference(Path.Combine(assemblyPath, "System.Core.dll")));
    	returnList.Add(new MetadataFileReference(Path.Combine(assemblyPath, "System.Runtime.dll")));
    
    	return returnList;
    }
