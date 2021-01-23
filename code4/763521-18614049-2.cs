    foreach(var pctm in prj.ProjectContents.ToList())
    {
       prj.ProjectContents.Remove(pctm);
       datacontext.ProjectContentTypeMappings.Remove(pctm);
    }
    datacontext.Remove(prj);
    datacontext.SaveChanges();
