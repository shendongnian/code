    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // ensure that commandArgument is not null, which may happen when someone tries to hack the page
        string isbn = e.CommandArgument.ToString();
        if (string.IsNullOrEmpty(uid))
        {
            // error message, someone has tried to hack the web page
            return;
        }
    
        if (e.CommandName == "viewDetails")
        {
            Response.Redirect("book-details.aspx?isbn=" + isbn);
            return;
        }
    
        // handle any other command that may be there (like delete, edit, etc)
    }
