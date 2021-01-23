    protected void insurancestatus_Click(object sender, ImageClickEventArgs e)
    {
        string vesselId = ((ImageButton)sender).CommandArgument;
       Response.Redirect(String.Format("~/Secure/getattachment.do?VesselId={0}", vesselId)); 
    }
