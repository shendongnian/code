    var p = Microsoft.Build.Evaluation
            .ProjectCollection.GlobalProjectCollection
            .LoadedProjects.FirstOrDefault(pr => pr.FullPath == projFilePath);
    if (p == null)
        p = new Microsoft.Build.Evaluation.Project(projFilePath);
    // Update instance of project
    p.ReevaluateIfNecessary();
    // Update the project as per response by @Boot750
    p.AddItem("Folder", @"C:\projects\BabDb\test\test2");
    p.AddItem("Compile", @"C:\projects\BabDb\test\test2\Class1.cs");
    p.Save();
