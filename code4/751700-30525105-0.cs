        var projects = from project in dc.ITProjects
                      orderby project.Id
                      select new
                      {
                          Phase = project.Phase.Value,
                          ProjectName = project.Project
                      }
                      ;
 
        int recordCount = projects.Count();
        int page = 0;
        int pageSize = 100;
 
        while(page*pageSize < recordCount)
        {
            foreach (var project in projects.Skip(page * pageSize).Take(pageSize))
            {
                Output0Buffer.AddRow();
                Output0Buffer.C1 = project.Phase;
                Output0Buffer.C2 = project.ProjectName;
            }
            page++;
        }
