    public static ProjectItem FindSolutionItemByName(DTE dte, string name, bool recursive)
    {
        ProjectItem projectItem = null;
        foreach (Project project in dte.Solution.Projects)
        {
            projectItem = FindProjectItemInProject(project, name, recursive);
            if (projectItem != null)
            {
                break;
            }
        }
        return projectItem;
    }
