    var workspace = Workspace.LoadSolution(solutionName);
    var solution = workspace.CurrentSolution;
    var createCommandList = new List<ISymbol>();
    var @class = solution.Projects.Select(s => s.GetCompilation()
                                                .GetTypeByMetadataName(className))
                                  .FirstOrDefault();
    var method = @class.GetMembers(methodName)
                        .AsList()
                        .Where(s => s.Kind == CommonSymbolKind.Method)
                        .Cast<MethodSymbol>()
                        .FirstOrDefault();
    var returnType = method.ReturnType as TypeSymbol;
    var returnTypeProperties = returnType.GetMembers()
                                         .AsList()
                                         .Where(s => s.Kind == SymbolKind.Property)
                                         .Select(s => s.Name);
