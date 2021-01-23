    protected void on_item_Command(object source, DataListCommandEventArgs e)
    {
       if (e.CommandName == "nav-to-page")
       {
           string s = (string)e.CommandArgument;
           Response.Redirect("NewPage.aspx?" + s);
       }
    }
