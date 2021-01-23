    protected void gvOnboardingMembers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvOnboardingMembers, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
                DataRowView dataItem = (DataRowView)e.Row.DataItem;
                if ((e.Row.RowState & DataControlRowState.Edit) == 0)
                {
                    LinkButton deleteButton = (LinkButton)e.Row.Cells[7].Controls[0];
                    if (deleteButton != null)
                        deleteButton.Attributes.Add("onclick", "return deleteOnboardingMember('" + dataItem["OnboardingMemberID"].ToString() + "');");
                }
            }
        }
    [WebMethod(EnableSession=true)]
        public static void DeleteOnboardingMember(string onboardingMemberID)
        {
            if(new processingClass().DeleteOnboardingMember(Guid.Parse(onboardingMemberID)))
                HttpContext.Current.Session["DraftMembers"] = null;
        }
