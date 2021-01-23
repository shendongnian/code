    public struct ProjectData
    {
        public string Name;
        public string Guid;
        public string Path;
    }
    public static List<ProjectData> GetProjectsInSolution(string pathToSolutionFile)
    {
        Type parserType = Type.GetType("Microsoft.Build.Construction.SolutionParser, Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false, false);
    
        ConstructorInfo constructorInfo = parserType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).First();
        object solutionParser = constructorInfo.Invoke(null);
                
        PropertyInfo solutionFileProperty = parserType.GetProperty("SolutionFile", BindingFlags.NonPublic | BindingFlags.Instance);
        solutionFileProperty.SetValue(solutionParser, pathToSolutionFile);
                
        MethodInfo parserMethod = parserType.GetMethod("ParseSolutionFile", BindingFlags.NonPublic | BindingFlags.Instance);
        parserMethod.Invoke(solutionParser, null);
    
        PropertyInfo projectInfo = parserType.GetProperty("Projects", BindingFlags.NonPublic | BindingFlags.Instance);
        object[] projects = projectInfo.GetValue(solutionParser) as object[];
    
        Type projectType = Type.GetType("Microsoft.Build.Construction.ProjectInSolution, Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false, false);
    
        PropertyInfo nameInfo = projectType.GetProperty("ProjectName", BindingFlags.NonPublic | BindingFlags.Instance);
        PropertyInfo guidInfo = projectType.GetProperty("ProjectGuid", BindingFlags.NonPublic | BindingFlags.Instance);
        PropertyInfo pathInfo = projectType.GetProperty("RelativePath", BindingFlags.NonPublic | BindingFlags.Instance);
    
        List<ProjectData> projectData = new List<ProjectData>();
                
        if (projects != null)
        {
            foreach (object project in projects)
            {
                projectData.Add(new ProjectData()
                {
                    Name = nameInfo.GetValue(project) as string,
                    Guid = guidInfo.GetValue(project) as string,
                    Path = pathInfo.GetValue(project) as string
                });
            }
        }
    
        return projectData;
    }
