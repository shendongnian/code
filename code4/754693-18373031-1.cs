      public void page_load()
        {
        if(!IsPostBack)
        {
        TextBox tb = (TextBox)PreviousPage.FindControl("Text1");
        Response.Write(tb.Text);}
        }
