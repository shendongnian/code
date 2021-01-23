    DAO.Database dd;
    DAO.DBEngine db = new DAO.DBEngine();
    dd = db.OpenDatabase(path);
    bool found= false;
    foreach(DAO.QueryDef qd in dd.QueryDefs)
    {
       if (qd.Name == "Hello")
       {
            found = true;
       }
    }
    if (found)
    {
       dd.QueryDefs.Delete(queryName);
    }
