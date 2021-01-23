    private List<CodeFunctionWithIndex> GetExplicitlyDefinedConstructors(vsCMElement pRequestedCodeElementKind, CodeElements pCodeElements)
    {
        int nbCodeFunction = 0; //calculated function index
        List<CodeFunctionWithIndex> constructorList = new List<CodeFunctionWithIndex>();
        if (pCodeElements != null)
        {
            foreach (CodeElement element in pCodeElements)
            {
                //if current element is a namespace
                if (element.Kind == vsCMElement.vsCMElementNamespace)
                {
                    constructorList = GetExplicitlyDefinedConstructors(pRequestedCodeElementKind, ((EnvDTE.CodeNamespace)element).Members);
                    if (!constructorList.Any())
                        continue;
                    return constructorList;
                }
                //if current element is a class
                else if (element.Kind == vsCMElement.vsCMElementClass)
                {
                    nbCodeFunction = 0;
                    constructorList = GetExplicitlyDefinedConstructors(pRequestedCodeElementKind, ((EnvDTE.CodeClass)element).Members);
                    if (!constructorList.Any()) //because there might be more than one class defined within the active file
                        continue;
                    return constructorList;
                }
                //if current element's kind equals the requested kind
                else if (element.Kind == pRequestedCodeElementKind)
                {
                    nbCodeFunction++;
                    //if it's a constructor, add its index to the list of constructor indexes
                    if (((CodeFunction)element).FunctionKind.ToString().Contains(vsCMFunction.vsCMFunctionConstructor.ToString()))
                    {
                        constructorList.Add(
                            new CodeFunctionWithIndex()
                            {
                                CodeFunction = ((CodeFunction)element),
                                Index = nbCodeFunction
                            });
                    }
                }
            }
        }
        return constructorList;
    }
