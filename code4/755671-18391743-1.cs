    void gvMainLog_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="Remove")
        {
            var id = Int32.Parse(e.CommandArgument);
            gvMainLog.DeleteRow(id);
        }
    }
