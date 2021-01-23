    public static IEnumerable<CodeModule> FindCodeModules(this VBE vbe, string projectName, string componentName)
    {
        var matches = 
            vbe.VBProjects.Cast<VBProject>()
                          .Where(project => project.Name == projectName)
                          .SelectMany(project => project.VBComponents.Cast<VBComponent>()
                                                                     .Where(component => component.Name == componentName))
                          .Select(component => component.CodeModule);
        return matches;
    }
