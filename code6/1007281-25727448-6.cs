    foreach (var q in queryList)
                {
                    var matchedProjects = (from project in unitOfWork.ProjectRepository
                                          .Find(p => p.IsActive && p is Project && new[] { p.Name, p.ProjectAddress.City.Name, p.ProjectAddress.Address1 }
                                           .Any(prjt=>prjt.Contains(q)))
                                           select project as Project).AsParallel().ToList();
                    allSearchedProject.AddRange(matchedProjects);
                }
