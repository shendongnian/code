    var projectsByApp = (from p in projects
                         from a in p.Applications
                         group p by a into g
                         select new {
                             Application= g.Key,
                             Projects = g.ToList()
                         }).ToList();
