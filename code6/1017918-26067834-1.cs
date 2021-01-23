    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int id = (int)(DataBinder.Eval(e.Row.DataItem, "ID"));
            Response.Write(id);
        }
    }
