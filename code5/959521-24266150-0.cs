    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in gvClientData.Rows)
        {
    
            if (((CheckBox)gvr.FindControl("chkdisplay")).Checked == true)
            {
                string Index = ((Label)gvr.FindControl("lblIndex")).Text;
                int GIIndex = Convert.ToInt32(Index);
                GI_InsureMaster insertclientinfo = vjdb.GI_InsureMasters.Single(upd => upd.GIMastIndex == GIIndex);
                insertclientinfo.SendToCompany = true;
                vjdb.SubmitChanges(); //HERE
            }
    
        }
        BindAgencyData();
        Response.Redirect(Request.RawUrl);
    }
