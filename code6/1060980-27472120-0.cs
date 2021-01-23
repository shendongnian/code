    IDictionary<string, object> options = new Dictionary<string, object>();
    options["Argument"] = new[] { filePath, profile };
    var pyEngine = Python.CreateEngine(options);
    var pyScope = pyEngine.CreateScope();
    string script = "xccdf-xml2tsv.py";
    pyScope.SetVariable(profile, options);
    
    pyEngine.ExecuteFile(script, pyScope);
