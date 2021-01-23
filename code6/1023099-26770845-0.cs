    page_load()
    {
        if(!isPostBack())
        {
            // DataBind normally
            myGridview.DataBind();
        }
        else
        {
            //Some intelligent way to remove commas before binding
        }
    }
