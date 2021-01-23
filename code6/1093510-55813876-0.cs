    protected void gvTemplates_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //GridView gv1 = (GridView)sender;
            //foreach (GridViewRow item in gv1.Rows)
            //{
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    PopupControlExtender pce = e.Row.FindControl("PopupControlExtender1") as PopupControlExtender;
                    string behaviorID = "pce_" + e.Row.RowIndex;
                    pce.BehaviorID = behaviorID;
                    Panel pnl = (Panel)e.Row.FindControl("Panel2");
                    string OnMouseOverScript = string.Format("$find('{0}').showPopup();", behaviorID);
                    string OnMouseOutScript = string.Format("$find('{0}').hidePopup();", behaviorID);
                    pnl.Attributes.Add("onmouseover", OnMouseOverScript);
                    pnl.Attributes.Add("onmouseout", OnMouseOutScript);
                }
            //}
        }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string GetDynamicContent(string contextKey)
        {
            StringBuilder b = new StringBuilder();
            b.Append("<table style='background-color:#f3f3f3; border: #4DB3A4 2px solid; ");
            b.Append("width:100px;height:100px; font-size:8pt; font-family:'lucida grande', tahoma, verdana, arial, sans-serif;' cellspacing='0' cellpadding='3'>");
            b.Append("<tr><td colspan='3' style='background-color:white;'>");
            b.Append(contextKey);
            b.Append("</td></tr>");
            b.Append("</table>");
            return b.ToString();
        }
