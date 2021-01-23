    protected void Grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Status = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Visit_Status"));
    
                if (Status == "1")
                {
                    e.Row.Attributes["style"] = "background-color: #28b779";
                }
                else
                {
                    e.Row.Attributes["style"] = "background-color: #da5554";
                }
            }        
        }
