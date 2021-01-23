        TextBox txtEligibility= (TextBox)fvSubscriber.FindControl("txtEligibility");
    
        fvSubscriber.ChangeMode(FormViewMode.Edit);
        fvSubscriber.DataBind(); 
        LifeLineDSEntities context = new LifeLineDSEntities():
    
        var program = from p in context.EligibilityPrograms
                      select p;
    
        DropDownList ddlEligibility = (DropDownList)(fvSubscriber.FindControl("ddlEligibility")));
    
        if (ddlEligibility != null)
        {
            ddlEligibility.DataSource = program;
            ddlEligibility.DataTextField = "ProgramName";
            ddlEligibility.DataValueField = "eligibilityCode";
            ddlEligibility.DataBind();
            if (txtEligibility != null)
            {
                if(!string.IsNullOrWhiteSpace(txtEligibility.Text))
                {
                    foreach (ListItem item in ddlEligibility.Items)
                    {
                        if (item.Text == txtEligibility.Text)
                        {
                            ddlEligibility.SelectedValue = txtEligibility.Text;
                        }
                    }
                }
            }
        }
    
