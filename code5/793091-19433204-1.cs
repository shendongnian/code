    public static ProjectItem FindProjectItemInProject(Project project, string name, bool recursive)
    {
        ProjectItem projectItem = null;
    
        if (project.Kind != Constants.vsProjectKindSolutionItems)
        {
            if (project.ProjectItems != null && project.ProjectItems.Count > 0)
            {
                projectItem = DteHelper.FindItemByName(project.ProjectItems, name, recursive);
            }
        }
        else
        {
            // if solution folder, one of its ProjectItems might be a real project
            foreach (ProjectItem item in project.ProjectItems)
            {
                Project realProject = item.Object as Project;
    
                if (realProject != null)
                {
                    projectItem = FindProjectItemInProject(realProject, name, recursive);
    
                    if (projectItem != null)
                    {
                        break;
                    }
                }
            }
        }
    
        return projectItem;
    }
