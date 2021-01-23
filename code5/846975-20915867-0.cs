    static IEnumerable<string> GetMethodCallParametersValues(string solutionName, 
                                                             string className, 
                                                             string methodName)
    {
        var workspace = Workspace.LoadSolution(solutionName);
        var solution = workspace.CurrentSolution;
        var createCommandList = new List<ISymbol>();
        var @class = solution.Projects.Select(s => s.GetCompilation()
                                                    .GetTypeByMetadataName(className))
                                      .FirstOrDefault();
        var method = @class.GetMembers(methodName)
                            .AsList()
                            .Where(s => s.Kind == CommonSymbolKind.Method)
                            .FirstOrDefault();
        var locations = method.FindReferences(solution)
                              .SelectMany(r => r.Locations);
        List<string> result = new List<string>();
        foreach (var location in locations)
        {
            var model = location.Document.GetSemanticModel();
            var token = location.Location
                                .SourceTree
                                .GetRoot()
                                .FindToken(location.Location.SourceSpan.Start);
            var invocation = token.Parent.FirstAncestorOrSelf<InvocationExpressionSyntax>();
            var arguments = invocation.ArgumentList.Arguments;
            result.AddRange(arguments.Select(a => model.GetConstantValue(a.Expression).Value.ToString()));
        }
        return result.Distinct();
    }
