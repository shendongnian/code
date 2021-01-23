    var ws = new AdhocWorkspace();
    var solutionInfo = SolutionInfo.Create(SolutionId.CreateNewId();, VersionStamp.Create());
    var solution = ws.AddSolution(solutionInfo);
    var project = ws.AddProject("Sample", "C#");
    //Add reference to mscorlib
    var mscorlib = PortableExecutableReference.CreateFromAssembly(typeof(object).Assembly);
    project = project.AddMetadataReference(mscorlib);
    ws.TryApplyChanges(project.Solution);
    string text = @"
    class C
    {
        void M()
        {
            //Missing a using System;
            Console.Write();
        }
    }";
    var sourceText = SourceText.From(text);
    //Add document to project
    var doc = ws.AddDocument(project.Id, "NewDoc", sourceText);
    var model = doc.GetSemanticModelAsync().Result;
    var unresolved = doc.GetSyntaxRootAsync().Result.DescendantNodes().OfType<IdentifierNameSyntax>()
       .Where(x => model.GetSymbolInfo(x).Symbol == null);
    foreach (var identifier in unresolved)
    {
        var candidateUsings = SymbolFinder.FindDeclarationsAsync(doc.Project, identifier.Identifier.ValueText, ignoreCase: false).Result;
        //Process candidate usings...
    }
