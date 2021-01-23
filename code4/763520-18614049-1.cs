    Project prj = new Project();
    //fill out scalar properties
    ProjectContentTypeMapping pctm = new ProjectContentTypeMapping();
    pctm.ContentTypeId = 1; //or whatever you want, or selected from UI
    
    prj.ProjectContents = new ProjectContentTypeMapping();
    prj.ProjectContents.Add(pctm);
    
    dataContext.Projects.Add(prj);
