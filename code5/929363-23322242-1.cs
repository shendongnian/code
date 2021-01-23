    var project = (from p in context.Projects select p);
    if(ddl1 != 0)
    {
        project = project.Where(Convert.ToInt32(p.DastgahEjraeiAsli) == ddl1);
    }
    if(ddl2 != 0)
    {
        project = project.Where(Convert.ToInt32(p.DastgahEjraeiAsli) == ddl2);
    }
    ...
