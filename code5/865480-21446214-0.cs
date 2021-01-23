    var root = (CompilationUnitSyntax)tree.GetRoot();
    var oldUsing = root.Usings[1];
    var newUsing = oldUsing.WithName(name); //changes the name property of a Using statement
    root = root.ReplaceNode(oldUsing, newUsing);
    
