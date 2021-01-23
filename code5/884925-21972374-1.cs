    protected void MySelectButtonToolTipManagerAjaxUpdate(
        object sender, ToolTipUpdateEventArgs e)
    {
        Control ctrl = Page.LoadControl(@"~/UserControls/MyUserControl.ascx");
        ctrl.ID = "MyUserControl";
        e.UpdatePanel.ContentTemplateContainer.Controls.Add(ctrl);           
        var li = (ctrl as MyUserControlClass);
        li.Initialize(MyViewStateCollection);
    }
