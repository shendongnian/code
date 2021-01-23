    class ProjectDTO
    {
        string ContentTitle; // Project.Content.Title becomes ProjectDTO.ContentTitle
        string ContentData;  // Project.Content.Data becomes ProjectDTO.ContentData
    }
 
    project.InjectFrom<UnflatLoopValueInjection>(projectDTO);
