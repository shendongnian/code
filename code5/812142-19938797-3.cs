    var ddlEligibility = ((DropDownList)(fvSubscriber.FindControl("ddlEligibility")));
    
    if(ddlEligibility!=null)
    {
       ddlEligibility.DataSource = program;
       ddlEligibility.DataBind();
    } 
    else
    {
       statusMesage.InnerHtml = "IT IS NULL";
    }
