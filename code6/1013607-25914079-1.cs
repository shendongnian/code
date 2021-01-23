    using(var DBContext = new DBEntities())
    {
       var records = DBContext.SP_GetRecords().ToList(); // Enumerate
       Repeater.DataSource = records; // will not                 
       Repeater.DataBind();
       Label.Text = records.Count().ToString();
    }
