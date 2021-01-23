    var p = Microsoft.Build.Evaluation
             .ProjectCollection.GlobalProjectCollection
             .LoadedProjects.FirstOrDefault(pr => pr.FullPath == projFilePath);
    if (p == null)
        p = new Microsoft.Build.Evaluation.Project(projFilePath);
    // Update instance of project
    p.ReevaluateIfNecessary();
