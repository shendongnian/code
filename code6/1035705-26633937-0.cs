        protected void rptVessels_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Button button = (Button)e.Item.FindControl("editview");
            button.OnClientClick = String.Format("return confirm('{0}')", GetLocalResourceObject("alertEditVesselText").ToString());
        }
