    var callers = method.FindCallers(solution, CancellationToken.None);
    foreach (var caller in callers)
    {
        foreach (var location in caller.Locations)
        {
            if (location.IsInSource)
            {
                var callerSemanticModel = solution
                    .GetDocument(location.SourceTree)
                    .GetSemanticModel();
                var node = location.SourceTree.GetRoot()
                    .FindToken(location.SourceSpan.Start)
                    .Parent;
                var symbolInfo = callerSemanticModel.GetSymbolInfo(node);
                var calledMethod = symbolInfo.Symbol as IMethodSymbol;
                if (calledMethod != null)
                {
                    var arguments = calledMethod.TypeArguments;
                }
            }
        }
    }
