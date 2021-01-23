    foreach (var u in GlobalDataModel.WellList
                                     .Where(u => u.RefProjectName == project.OldProjectName)) 
    {
        u.RefProjectName = project.ProjectName;
    }
