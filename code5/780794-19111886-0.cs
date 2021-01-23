    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Control c = GetPostBackControl(this.Page);
            string ctrlId = c.ID;
        }
    }
     private Control GetPostBackControl(Page page)
    {
        Control control = null;
        string postBackControlName = Request.Params.Get("__EVENTTARGET");
        string eventArgument = Request.Params.Get("__EVENTARGUMENT");
        if (postBackControlName != null && postBackControlName.Length > 0)
        {
            control = Page.FindControl(postBackControlName);
        }
        else
        {
            foreach (string str in Request.Form)
            {
                Control c = Page.FindControl(str);
                if (c is Button)
                {
                    control = c;
                    break;
                }
            }
        }
        return control;
    }
