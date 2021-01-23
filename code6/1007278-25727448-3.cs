    var matchedProjects = (from project in unitOfWork.ProjectRepository
        .Find(p => p.IsActive && p is Project && new[] { p.Name, p.ProjectAddress.City.Name, p.ProjectAddress.Address1 }
        .Any(prjt=>queryList.Contains(prjt))
        select project as Project).AsParallel().ToList();
        allSearchedProject.AddRange(matchedProjects);
                
