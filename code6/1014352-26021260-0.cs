    protected void fvWasteCollected_DataBound(object sender, EventArgs e)
        {
            FormView formview = fvWasteCollected;
            FormViewRow row = fvWasteCollected.Row;
            DataRowView rowview = (DataRowView)fvWasteCollected.DataItem;
            Panel pnlOtherContractor = (Panel)fvWasteCollected.FindControl("pnlOtherContractor2");
            if (fvWasteCollected.CurrentMode == FormViewMode.Edit)
            {
                var s_contractorId = rowview["MRWContractorId"].ToString();
                if (s_contractorId == "0")
                {
                    pnlOtherContractor.Visible = true;
                }
                else
                {
                    pnlOtherContractor.Visible = false;
                }
            }
        }
   
