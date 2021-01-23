    using (var context = new PROJECT_DBEntities())
    {
        // It's useless to initialize the lst variable by a new List
        var lst = context.FirstInternships // No need to write SQL
                         .ToList();        // No need to specify the type
    
        repeater1.DataSource = lst;
        repeater1.DataBind();
    }
