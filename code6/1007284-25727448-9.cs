    var matchedProjects = (from project in unitOfWork.ProjectRepository
        where project.IsActive 
          && project is Project
          && (queryList.Contains(project.Name) 
             || queryList.Contains(project.ProjectAddress.City.Name)
             || queryList.Contains(project.ProjectAddress.Address1))
        select project as Project).AsParallel().ToList();
        allSearchedProject.AddRange(matchedProjects);
                
