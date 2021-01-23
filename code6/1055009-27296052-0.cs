    if (ProjectCollection.GlobalProjectCollection.GetLoadedProjects(xmlProject).Count == 0)
    {
           var proj =
                        new Project(
                            xmlProject,
                            null,
                            null,
                            ProjectCollection.GlobalProjectCollection,
                            ProjectLoadSettings.Default);
    }
