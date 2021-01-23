    public List<IR_INVESTIGATION> AddRowToRepeater()
    {
        List<IR_INVESTIGATION> lstEntered = new List<IR_INVESTIGATION>();
        using (EHSIMSDataContext db = new EHSIMSDataContext())
        {
            foreach (RepeaterItem itm in rptinvest.Items)
            {
                DropDownList ddlemployee = itm.FindControl("ddlemployee") as DropDownList;
                DropDownList ddlrole = itm.FindControl("ddlrole") as  DropDownList;
                TextBox email = itm.FindControl("email") as TextBox;
                TextBox depart = itm.FindControl("depart") as TextBox;
                TextBox pos = itm.FindControl("pos") as TextBox;
                IR_INVESTIGATION abKeyword = new IR_INVESTIGATION();
                lstEntered.Add(abKeyword);
            }
        }
        
        return lstEntered;
    }
