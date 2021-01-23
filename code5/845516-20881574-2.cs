    private void AddRulePropertyControl()
    {
        RuleProperty Control = (RuleProperty)LoadControl("RuleProperty.ascx");         
        Control.ButtonClick += RuleProperty_ButtonClick;
        MyPanel.Controls.Add(Control);
    }
    private void RuleProperty_ButtonClick()
    {
        ViewState["AddRuleProperty"] = false;
    }
