    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == GridView1.EditIndex)
                {
                    //update or cancel buttons
                    LinkButton updateBtn = (LinkButton)e.Row.Cells[0].Controls[0];
                    string updateScript = string.Format("document.getElementById('{0}').click(); return false;", updateBtn.ClientID);
                    Button1.OnClientClick = updateScript;
                    LinkButton cancelBtn = (LinkButton)e.Row.Cells[0].Controls[2];
                    string cancelScript = string.Format("document.getElementById('{0}').click(); return false;", cancelBtn.ClientID);
                    Button2.OnClientClick = cancelScript;
                }
                else
                {
                    //edit button
                    LinkButton editBtn = (LinkButton)e.Row.Cells[0].Controls[0];
                    string editScript = string.Format("document.getElementById('{0}').click();", editBtn.ClientID);
                    e.Row.Attributes["onclick"] = editScript;
                }
            }
            if (GridView1.EditIndex >= 0)
            {
                Button1.Enabled = true;
                Button2.Enabled = true;
            }
            else
            {
                Button1.Enabled = false;
                Button2.Enabled = false;
            }
        }
