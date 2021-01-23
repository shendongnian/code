    int index = 0;
    foreach(Project project in dte.Solution.Projects)
    {
        if (string.Equals(project.Name, "desired project name"))
        {
            break;
        }
        index++;
    }
