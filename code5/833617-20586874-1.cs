    var solutionFiles = new List<FileInfo>();
    var trees = new Dictionary<FileInfo, SyntaxTree>();
    IProjectContent projectContent = new CSharpProjectContent();
    foreach (var file in solutionFiles.Where(f => f.Extension == ".cs").Distinct())
    {
        var parser = new ICSharpCode.NRefactory.CSharp.CSharpParser();
        SyntaxTree syntaxTree;
        using (var fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan))
        {
            syntaxTree = parser.Parse(fs, file.FullName);
        }
        trees.Add(file, syntaxTree);
        var unresolvedFile = syntaxTree.ToTypeSystem();
        projectContent = projectContent.AddOrUpdateFiles(unresolvedFile);
    }
    var compilation = projectContent.CreateCompilation();
        
    foreach (var sharpFile in trees)
    {
        var originalResolver = new CSharpAstResolver(compilation, sharpFile.Value, sharpFile.Value.ToTypeSystem());
        var visitor = new MissingInterfaceMemberImplementationVisitor(originalResolver);
        sharpFile.Value.AcceptVisitor(visitor);
        if (visitor.IsInterfaceMemberMissing)
           return false;
        }
    return true;
