    var projectLookup = usersProjects.ToLookup((x) => x.Code);
    foreach (Project prj in projectList)
        {
            string prjCode = prj.Code;
            
            var match = projectLookup[prjCode].FirstOrDefault()
            if (match != null)
            {
                //More logic here
            }
        }
