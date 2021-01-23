    IWorkspace workspace = Workspace.LoadSolution(@"..\RoslynTest.sln");
    var originalSolution = workspace.CurrentSolution;
    var project = originalSolution.GetProject(originalSolution.ProjectIds.First());
    IDocument doc = project.AddDocument("index.html", "<html></html>");
    workspace.ApplyChanges(originalSolution, doc.Project.Solution);
