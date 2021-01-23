    protected void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["AddRuleProperty"] != null && (bool)ViewState["AddRuleProperty"])
        {
            AddRulePropertyControl();
        }
    }
    
    protected void btnAddRules_Click(object sender, EventArgs e)
    {
        AddRulePropertyControl();          
        ViewState["AddRuleProperty"] = true;
    }
    
    private void AddRulePropertyControl()
    {
        RuleProperty Control = (RuleProperty)LoadControl("RuleProperty.ascx");         
        MyPanel.Controls.Add(Control);
    }
