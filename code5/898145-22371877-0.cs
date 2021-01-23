    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool statusFlag=false;
        if (ViewState["RowIndexPOS"] != null)
        {
            int iRowIndex = Convert.ToInt32(ViewState["RowIndexPOS"]);
            Label lblStatus = (Label)GridViewMultiplePOSAssociationId.Rows[iRowIndex].FindControl("LabelStatusPendingPOSId");
            //Means all rows in GridView are successfully associated
            if (table.Rows.Count == iResultCount)
            {
                lblStatus.Text = "Associated";
                statusFlag=true;
            }
            else
            {
                lblStatus.Text = "Pending";
                statusFlag=false;
            }
        }
        //now call the binding method with the bool flag value
         bindTheGriView(statusFlag)
    }
