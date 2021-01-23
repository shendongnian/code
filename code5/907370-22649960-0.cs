    var projectA = new Project();
    var projectB = new Project();
    var dep1 = new ProjectDependency
    {
        Project = projectA,
        Dependent = projectB
    };
    projectA.ProjectDependencies.Add(dep1);
