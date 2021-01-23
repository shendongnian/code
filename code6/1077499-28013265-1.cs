    [GeneratorElementProvider("MyGeneratorProvider", typeof(CSharpLanguage))]
    public class MyGeneratorProvider : GeneratorProviderBase<CSharpGeneratorContext>
    {
    	public override double Priority
    	{
    		get { return 0; }
    	}
    
    	public override void Populate(CSharpGeneratorContext context)
    	{
    		var projectCsFiles = GetAllCSharpFilesInProject(context.PsiModule);
    		var declarations = projectCsFiles.SelectMany(GetDeclarationsFromCSharpFile).ToList();
    		context.ProvidedElements.AddRange(declarations.Select(d => new GeneratorDeclarationElement(d)));
    	}
    
    	private static IEnumerable<ICSharpFile> GetAllCSharpFilesInProject(IPsiModule projectModule)
    	{
    		PsiManager psiManager = projectModule.GetPsiServices().PsiManager;
    		return projectModule.SourceFiles.SelectMany(f => psiManager.GetPsiFiles<CSharpLanguage>(f).OfType<ICSharpFile>());
    	}
    
    	private static IEnumerable<ITypeDeclaration> GetDeclarationsFromCSharpFile(ICSharpFile file)
    	{
    		return file.NamespaceDeclarationNodes.SelectMany(GetDeclarationsFromCSharpNamespace);
    	}
    
    	private static IEnumerable<ITypeDeclaration> GetDeclarationsFromCSharpNamespace(ICSharpNamespaceDeclaration namespaceDeclaration)
    	{
    		foreach (var namespaceChild in namespaceDeclaration.Body.Children())
    		{
    			var classDeclaration = namespaceChild as IClassDeclaration;
    			if (classDeclaration != null)
    			{
    				yield return classDeclaration;
    			}
    			else
    			{
    				var childNamespace = namespaceChild as ICSharpNamespaceDeclaration;
    				if (childNamespace != null)
    				{
    					foreach (var declaration in GetDeclarationsFromCSharpNamespace(childNamespace))
    					{
    						yield return declaration;
    					}
    				}
    			}
    		}
    	}
    }
