    private void FormatFiles(Project project, List<ProjectItem> ProjectItems)
    {
        for (int i = 0; i < ProjectItems.Count- 1; i++)
        {
            ProjectItems[i].Open();
            FromatFileIsOpened(ProjectItems[i]);
            ProjectItems[i].Document.Close();
        }
    }
    private void FromatFileIsOpened(ProjectItem formatFile)
    {
        try
        {
            formatFile.Document.Activate();
            formatFile.DTE.ExecuteCommand("Edit.FormatDocument");
        }
        catch
        {
           FromatFileIsOpened(formatFile);
        }
    }
