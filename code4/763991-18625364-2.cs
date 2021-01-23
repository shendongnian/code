    protected void loadUserControl(string tmUCName)
    {
        phDetail.Controls.Clear();
        ViewState["vsControl"] = null;
        UserControl tmUControl = LoadControl(tmUCName) as UserControl;
        tmUControl.ID = "ucidControl";
        phDetail.Controls.Add(tmUControl);
        ViewState["vsControl"] = tmUCName;
        ((IMyUserControl)tmUControl).SelectedIndexChanged += // <- put your delegate here
    }
