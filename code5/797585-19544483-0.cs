    protected void Page_Load(object sender, EventArgs e)
    {
        string _action = this.Request.Params.Get("__EVENTTARGET");
        if (_action == "XX")
        {
            UpdatePanel pnl = ((UpdatePanel)TabControl1.FindControl("UpdatePanel ID"));
            UserControl uc = (UserControl)LoadControl("MyForm.ascx");
            pnl.ContentTemplateContainer.Controls.Clear();
            pnl.ContentTemplateContainer.Controls.Add(uc);
            pnl.Update();
        }
    }
