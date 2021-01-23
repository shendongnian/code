        protected void gvListele_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dbeDataContext db = new dbeDataContext();
        var c = (from v in db.CAGRIs where v.UserID != Convert.ToInt32(Session["user"]) select v).ToArray();
        if (c != null)
        {
            foreach (var item in c)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int callID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CagriID"));
                    if (callID == item.CagriID)
                    {
                        e.Row.Enabled = false;
                        continue;
                    }
                }
            }
        }
    }
