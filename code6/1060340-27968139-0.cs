    var solution = new Solution(slnPath);
    
    IDictionary<AstNode, IType> typesMap = new Dictionary<AstNode, IType>();
    
    IDictionary<AstNode, IMember> membersMap = new Dictionary<AstNode, IMember>();
    
    var navigator = new FindReferencedEntities(typesMap.Add, membersMap.Add);
    
    foreach (var codeFile in solution.AllFiles)
    {
    	codeFile.CreateResolver().ApplyNavigator(navigator);
    }
