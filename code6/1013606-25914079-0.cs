    using(var DBContext = new DBEntities())
    {
       var records = DBContext.SP_GetRecords().ToList();
       Repeater.DataSource = records;                
       Repeater.DataBind();
       Label.Text = records.Count().ToString();
    }
