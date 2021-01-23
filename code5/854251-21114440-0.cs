    public object Cagris
    {  
        get
        {
            if(_cagris == null)
            {
                 _cagris =  (from v in db.CAGRIs 
                             where v.UserID != Convert.ToInt32(Session["user"]) // the session variable I would also have as a property rather than access it each time like this. 
                             select v).ToArray();
            }
            return _cagris;
        }
    }
    protected void gvListele_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Cargis != null)
            {
                foreach (var item in Cargis)
                {
                    //now you can either get the DataRow  
                    DataRow dr = e.Row;
                    int tempID = int.Parse((string)dr["CagriID"]);
                    
                    if (item.CagriID == tempID)
                    {
                        e.Row.Enabled = false;
                    }
                    //or use the DataItem
                    Cagris c = (Cagris)e.Row.DataItem;
                    if (item.CagriID == c.CagriID)
                    {
                        e.Row.Enabled = false;
                    }
                }
            }
        }
    }
