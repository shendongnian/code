    var matchedProjects = (from project in unitOfWork.ProjectRepository
        .Find(p => p.IsActive && p is Project)
        .Any(prjt=>queryList.Contains(prjt.Name) 
             || queryList.Contains(prjt.ProjectAddress.City.Name)
             || queryList.Contains(prjt.ProjectAddress.Address1))
        select project as Project).AsParallel().ToList();
        allSearchedProject.AddRange(matchedProjects);
                
