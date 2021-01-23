    protected void rptGallary_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //add command name to btnLike button let it bet test here
        if (e.CommandName == "test")
        {
             HiddenField hiddenfield=          (HiddenField)e.Item.Parent.Parent.FindControl("hfsportsmanfeedid");
         //pass that to javascript
        }
    }
