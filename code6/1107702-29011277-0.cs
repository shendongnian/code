    bool validCode = true;
    string[] unallowedMethods = new string[] { ... };
    string sourceCode = ...;
    ICodeCompiler codeCompiler = ...;
    CompilerResults results = codeCompiler.CompileAssemblyFromSource(parameters, sourceCode);
    validCode = result.Errors.Count == 0;
    if (validCode)
     foreach (method in unallowedMethods)
       if (sourceCode.Contains(method)))
       //improve this by checking if occurrence is not a string literal in program 
       {
          validCode = false;
          break;
       }
