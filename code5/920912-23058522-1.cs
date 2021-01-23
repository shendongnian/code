    protected void OriginalTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var selectedIDs = (Session["CheckedIDs"] != null) ? 
            Session["CheckedIDs"] as List<int> : new List<int>();
        //we are now at current page. set the checked ids to a list
        foreach (GridViewRow row in OriginalTable.Rows)
        {
            //get the checkbox in the row ( "HasEmail" is the name of the asp:CheckBox )
            var emailCheckBox = row.FindControl("HasEmail") as CheckBox;
            //gets the primary key of the corresponding row
            var rowOrgID = Convert.ToInt32(OriginalTable.DataKeys[row.RowIndex].Value);
            //is row org_id in the selectedIDs list
            var isRowIDPresentInList = selectedIDs.Contains(rowOrgID);
            // add to list
            if (emailCheckBox.Checked && !isRowIDPresentInList)
            {
                selectedIDs.Add(rowOrgID);
            }
            //remove from list
            if (!emailCheckBox.Checked && isRowIDPresentInList)
            {
                selectedIDs.Remove(rowOrgID);
            }
        }
        OriginalTable.PageIndex = e.NewPageIndex;
        BindTable();
        //we are now at the new page after paging
        //get the select ids and make the gridview checkbox checked accordingly
        foreach (GridViewRow row in OriginalTable.Rows)
        {
            var emailCheckBox = row.FindControl("HasEmail") as CheckBox;
            var rowOrgID = Convert.ToInt32(OriginalTable.DataKeys[row.RowIndex].Value);
            if (selectedIDs.Contains(rowOrgID))
            {
                emailCheckBox.Checked = true;
            }
        }
        Session["CheckedIDs"] = (selectedIDs.Count > 0) ? selectedIDs : null;
    }
