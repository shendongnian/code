     protected void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvRow in grdUser.Rows)
            {
                if (gvRow.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkDelete = (CheckBox)gvRow.FindControl("chkDelete");
                    if (chkDelete.Checked)
                    {
                        string Id = grdUser.DataKeys[gvRow.RowIndex].Value.ToString();
                        DeleteRecordByID(Id);
                    }
                }
            }
           //Bind your Gridview here
        }
