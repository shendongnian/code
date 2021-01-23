    var project = new ProjectData();
    session.Save(project);
    session.Flush();
    var freshProject = session.Get<ProjectData>(project.Id);
    if (ReferenceEquals(project, freshProject))
        Console.WriteLine("They're the same instance.");
