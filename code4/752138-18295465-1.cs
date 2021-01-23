    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            return;
        Control control = null;
        string controlName = Page.Request.Params["__EVENTTARGET"];
        if (!String.IsNullOrEmpty(controlName))
        {
            control = Page.FindControl(controlName);
        }
        else
        {
            string controlId;
            Control foundControl;
            foreach (string ctl in Page.Request.Form)
            {
                if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                {
                    controlId = ctl.Substring(0, ctl.Length - 2);
                    foundControl = Page.FindControl(controlId);
                }
                else
                {
                    foundControl = Page.FindControl(ctl);
                }
                if (!(foundControl is Button || foundControl is ImageButton)) continue;
                control = foundControl;
                break;
            }
        }
        Label1.Text = control.ID; // label1 must be in UpdatePanel
    }
