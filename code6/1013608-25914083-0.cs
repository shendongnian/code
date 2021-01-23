    using(var DBContext = new DBEntities())
    {
       var results = DBContext.SP_GetRecords();
       Repeater.DataSource = results;                
       Repeater.DataBind();
       Label.Text = results.Count.ToString();
    }
