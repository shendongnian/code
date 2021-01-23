    protected void btnConfirm_Click(object sender, EventArgs e) 
    {
        LinkButton btn = (LinkButton)sender;
        ListViewDataItem row = btn.NamingContainer as ListViewDataItem;
    
        if (row != null)
        {
            HiddenField hiddenFieldWithSomething = row.FindControl("hiddenControl") as HiddenField;
            //var lastControlWithFocusClientId = cphContainer_ucTakeTest_lvData_txtAnswer_0";
            if (hiddenFieldWithSomething.ClientID == lastControlWithFocusClientId) 
            {
                //Do something here
            }
        }
    }
